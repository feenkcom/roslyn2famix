using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("SourceAnchor")]
    public class SourceAnchor : FAMIX.Entity
    {
        [FameProperty(Name = "element", Opposite = "sourceAnchor")]
        public FAMIX.SourcedEntity element { get; set; }

    }
}
