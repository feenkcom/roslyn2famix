using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("TraitUsage")]
    public class TraitUsage : FAMIX.Association
    {
        [FameProperty(Name = "trait", Opposite = "incomingTraitUsages")]
        public FAMIX.Trait trait { get; set; }

        [FameProperty(Name = "user", Opposite = "outgoingTraitUsages")]
        public FAMIX.Type user { get; set; }

    }
}
