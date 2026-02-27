using FiniteStateMachinesToPetriNets.FiniteStateMachines;
using FiniteStateMachinesToPetriNets.PetriNets;
using FiniteStateMachinesToPetriNets.Synchronization;
using NMF.AnyText;
using System.Diagnostics;

#if DEBUG
if (args.Length == 1 && args[0] == "debug")
{
    Debugger.Launch();
}
#endif
await SynchronizationBootstrapper.RunLspServerOnStandardInStandardOutAsync([
       new FiniteStateMachinesGrammar(),
       new PetriNetGrammar()
    ],
    [
        new ModelSynchronization<StateMachine, PetriNet, FiniteStateToPetriNetSynchronization, FiniteStateToPetriNetSynchronization.AutomataToNet>
        {
            IsAutomatic = true,
            LeftExtension = ".fsm",
            RightExtension = ".pn"
        }
    ]);
