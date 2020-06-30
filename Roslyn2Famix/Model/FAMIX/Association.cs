using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Association")]
    public class Association : FAMIX.SourcedEntity
    {
        [FameProperty(Name = "next", Opposite = "previous")]
        public FAMIX.Association next { get; set; }

        [FameProperty(Name = "previous", Opposite = "next")]
        public FAMIX.Association previous { get; set; }

    }
}
