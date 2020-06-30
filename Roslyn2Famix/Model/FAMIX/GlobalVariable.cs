using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("GlobalVariable")]
    public class GlobalVariable : FAMIX.StructuralEntity
    {
        [FameProperty(Name = "parentModule")]
        public FAMIX.VBModule parentModule { get; set; }

        [FameProperty(Name = "parentScope", Opposite = "globalVariables")]
        public FAMIX.ScopingEntity parentScope { get; set; }

    }
}
