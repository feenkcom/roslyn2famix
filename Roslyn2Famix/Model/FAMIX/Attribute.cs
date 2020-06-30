using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Attribute")]
    public class Attribute : FAMIX.StructuralEntity
    {
        [FameProperty(Name = "hasClassScope")]
        public Boolean hasClassScope { get; set; }

        [FameProperty(Name = "hierarchyNestingLevel")]
        public int hierarchyNestingLevel { get; set; }

        [FameProperty(Name = "parentType", Opposite = "attributes")]
        public FAMIX.Type parentType { get; set; }

    }
}
