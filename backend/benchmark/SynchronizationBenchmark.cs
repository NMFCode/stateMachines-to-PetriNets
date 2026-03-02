using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using FiniteStateMachinesToPetriNets.FiniteStateMachines;
using FiniteStateMachinesToPetriNets.PetriNets;
using FiniteStateMachinesToPetriNets.Synchronization;
using Moq;
using NMF.AnyText;
using NMF.AnyText.Grammars;
using NMF.AnyText.Workspace;
using NMF.Synchronizations;
using NMF.Transformations;
using System.Management;

namespace Benchmark
{
    [SimpleJob(iterationCount: 10, warmupCount: 3, invocationCount: 1)]
    [MarkdownExporter]
    [RPlotExporter]
    [CsvExporter]
    public class SynchronizationBenchmark
    {
        [Params(100, 1000, 10_000, 100_000)]
        public int Size { get; set; }


        private static Random R = new Random(23);
        private StateMachine _stateMachine;
        private ModelSynchronization _synchronization;
        private SynchronizationService _synchronizationService;
        private Grammar _fsmGrammar;
        private Grammar _pnGrammar;

        private Parser _fsmParser;
        private Parser _pnParser;


        [GlobalSetup]
        public void Init()
        {
            _fsmGrammar = new FiniteStateMachinesGrammar();
            _pnGrammar = new PetriNetGrammar();
            _synchronization = new ModelSynchronization<StateMachine, PetriNet, FiniteStateToPetriNetSynchronization, FiniteStateToPetriNetSynchronization.AutomataToNet>
            {
                IsAutomatic = true,
                LeftExtension = ".fsm",
                RightExtension = ".pn",
                Direction = SynchronizationDirection.LeftWins
            };
            _fsmGrammar.Initialize();
            _pnGrammar.Initialize();

            // this is to make sure that class instances are loaded
            Console.WriteLine(StateMachine.ClassInstance.Name);
            Console.WriteLine(PetriNet.ClassInstance.Name);
        }

        [IterationSetup]
        public void PrepareBenchmark()
        {
            _stateMachine = BenchmarkHelper.CreateRandomStateMachine(Size);
            _fsmParser = _fsmGrammar.CreateParser();
            _pnParser = _pnGrammar.CreateParser();

            var lspMock = new Mock<ILspServer>();
            lspMock.Setup(l => l.ApplyWorkspaceEditAsync(It.IsAny<WorkspaceEdit>(), It.IsAny<string>()))
                .Returns((WorkspaceEdit edit, string label) =>
                {
                    return Task.FromResult(new LspTypes.ApplyWorkspaceEditResponse());
                });

            _synchronizationService = new SynchronizationService(lspMock.Object, null, [_synchronization]);

            File.Create("test.fsm").Dispose();
            File.Create("test.pn").Dispose();

            _fsmParser.Initialize(new Uri(Path.GetFullPath("test.fsm")));
            _pnParser.Initialize(new Uri(Path.GetFullPath("test.pn")));

            _fsmParser.Initialize(_stateMachine);

            _synchronizationService.StartSynchronizing(_fsmParser, []);
            _synchronizationService.StartSynchronizing(_pnParser, [_fsmParser]);
        }

        [Benchmark]
        public void ChangeStateName()
        {
            var stateIndex = R.Next(_stateMachine.States.Count);
            var endLine = _fsmParser.Context.Input[stateIndex + 2].Length;
            var position = new ParsePosition(stateIndex + 2, endLine);
            _synchronizationService.PrepareUpdate(_fsmParser);
            _fsmParser.Update(new TextEdit(position, position, ["Changed"]));
            _synchronizationService.CompleteUpdate(_fsmParser);
        }

        [Benchmark]
        public void RemoveTransition()
        {
            var transitionIndex = R.Next(_stateMachine.Transitions.Count - 1);
            var line = _stateMachine.States.Count + 5 + transitionIndex;
            _synchronizationService.PrepareUpdate(_fsmParser);
            _fsmParser.Update(new TextEdit(new ParsePosition(line, 0), new ParsePosition(line + 1, 0), [""]));
            _synchronizationService.CompleteUpdate(_fsmParser);
        }

        [Benchmark]
        public void SetStateAsInitial()
        {
            var stateIndex = GetRandomNonInitialStateIndex();
            var position = new ParsePosition(stateIndex + 2, 4);
            _synchronizationService.PrepareUpdate(_fsmParser);
            _fsmParser.Update(new TextEdit(position, position, ["initial "]));
            _synchronizationService.CompleteUpdate(_fsmParser);
        }

        [Benchmark]
        public void AddTargetPlace()
        {
            var stateIndex = R.Next(_stateMachine.States.Count);
            ParsePosition pos = GetTransitionPosition();
            _synchronizationService.PrepareUpdate(_pnParser);
            _pnParser.Update(new TextEdit(pos, pos, [_stateMachine.States[stateIndex].Name]));
            _synchronizationService.CompleteUpdate(_pnParser);
        }

        [IterationCleanup]
        public void Cleanup()
        {
            GC.Collect();
        }

        private ParsePosition GetTransitionPosition()
        {
            var transitionIndex = GetTransitionIndexWithoutEndPlace();
            var line = 4 * transitionIndex + 4;
            while (true)
            {
                var col = _pnParser.Context.Input[line].IndexOf(']');
                if (col > 0 && _pnParser.Context.Input[line].Contains("to []"))
                {
                    var pos = new ParsePosition(line, col);
                    return pos;
                }
                line--;
            }
        }

        private int GetRandomNonInitialStateIndex()
        {
            var stateIndex = R.Next(_stateMachine.States.Count);
            while (_stateMachine.States[stateIndex].IsInitial)
            {
                stateIndex = R.Next(_stateMachine.States.Count);
            }
            return stateIndex;
        }

        private int GetTransitionIndexWithoutEndPlace()
        {
            var pn = _pnParser.Context.Root as PetriNet;
            for (int i = pn.Transitions.Count - 1; i >= 0; i--)
            {
                if (pn.Transitions[i].To.Count == 0)
                {
                    return i;
                }
            }
            throw new InvalidOperationException();
        }
    }
}
