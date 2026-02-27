using NMF.AnyText;

namespace FiniteStateMachinesToPetriNets.FiniteStateMachines
{
    public partial class FiniteStateMachinesGrammar
    {
        public partial class StateRule
        {
            public override SymbolKind SymbolKind => SymbolKind.Class;
        }

        public partial class TransitionRule
        {
            public override SymbolKind SymbolKind => SymbolKind.Method;
        }
    }
}
