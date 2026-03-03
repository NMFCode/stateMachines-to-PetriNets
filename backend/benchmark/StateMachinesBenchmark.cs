using BenchmarkDotNet.Attributes;
using FiniteStateMachinesToPetriNets.FiniteStateMachines;
using NMF.AnyText;
using NMF.AnyText.Grammars;

namespace Benchmark
{

    [SimpleJob(iterationCount: 50, warmupCount: 5, invocationCount: 1)]
    [MarkdownExporter]
    [RPlotExporter]
    [CsvExporter]
    public class StateMachinesBenchmark
    {
        [Params(100, 1000, 10_000, 100_000)]
        public int Size { get; set; }

        [Params(UpdateMode.ReInitialize, UpdateMode.Update, UpdateMode.UpdateWithFeature)]
        public UpdateMode Mode { get; set; }

        private static Random R = new Random(23);
        private StateMachine _stateMachine;
        private Grammar _grammar;

        private Parser _parser;

        [GlobalSetup]
        public void Init()
        {
            _stateMachine = BenchmarkHelper.CreateRandomStateMachine(Size);
            _grammar = new FiniteStateMachinesGrammar();
            _grammar.Initialize();
        }

        [IterationSetup]
        public void PrepareBenchmark()
        {
            _parser = _grammar.CreateParser();
            _parser.Initialize(_stateMachine);
        }

        [Benchmark]
        public void ChangeName()
        {
            var s = RandomState();
            s.Name += "Changed";
            Update(s, "name", true);
        }

        [Benchmark]
        public void AddTransition()
        {
            var source = RandomState();
            var dest = RandomState();
            _stateMachine.Transitions.Add(new Transition
            {
                StartState = source,
                EndState = dest,
                Input = "z"
            });
            Update(_stateMachine, "transitions");
        }

        [Benchmark]
        public void ToggleIsFinal()
        {
            var s = RandomState();
            s.IsFinal = !s.IsFinal;
            Update(s, "isFinal");
        }

        private void Update(object changedElement, string feature, bool updateReferences = false)
        {
            switch (Mode)
            {
                case UpdateMode.ReInitialize:
                    _parser.Initialize(_stateMachine);
                    break;
                case UpdateMode.Update:
                    _parser.Update(changedElement);
                    break;
                case UpdateMode.UpdateWithFeature:
                    _parser.Update([new ModelUpdate(changedElement, [feature], updateReferences)]);
                    break;
            }
        }

        private IState RandomState() => _stateMachine.States[R.Next(_stateMachine.States.Count)];
    }
}
