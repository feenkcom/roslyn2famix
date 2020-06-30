using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("ImplicitVariable")]
    public class ImplicitVariable : FAMIX.StructuralEntity
    {
        [FameProperty(Name = "parentBehaviouralEntity", Opposite = "implicitVariables")]
        public FAMIX.BehaviouralEntity parentBehaviouralEntity { get; set; }

    }
}
