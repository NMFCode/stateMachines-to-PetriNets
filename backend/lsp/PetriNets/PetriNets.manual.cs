using NMF.AnyText;
using System;
using System.Collections.Generic;
using System.Text;

namespace FiniteStateMachinesToPetriNets.PetriNets
{
    public partial class PetriNetGrammar
    {
        public partial class PlaceRule
        {
            public override SymbolKind SymbolKind => SymbolKind.Interface;
        }

        public partial class TransitionRule
        {
            public override SymbolKind SymbolKind => SymbolKind.Event;
        }
    }
}
