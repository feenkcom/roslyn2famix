using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Reference")]
    public class Reference : FAMIX.Association
    {
        [FameProperty(Name = "source", Opposite = "outgoingReferences")]
        public FAMIX.BehaviouralEntity source { get; set; }

        [FameProperty(Name = "target", Opposite = "incomingReferences")]
        public FAMIX.Type target { get; set; }

    }
}
