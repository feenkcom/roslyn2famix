using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("LocalVariable")]
    public class LocalVariable : FAMIX.StructuralEntity
    {
        [FameProperty(Name = "parentBehaviouralEntity", Opposite = "localVariables")]
        public FAMIX.BehaviouralEntity parentBehaviouralEntity { get; set; }

    }
}
