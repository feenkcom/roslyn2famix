using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Parameter")]
    public class Parameter : FAMIX.StructuralEntity
    {
        [FameProperty(Name = "parentBehaviouralEntity", Opposite = "parameters")]
        public FAMIX.BehaviouralEntity parentBehaviouralEntity { get; set; }

    }
}
