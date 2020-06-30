using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("SourceTextAnchor")]
    public class SourceTextAnchor : FAMIX.SourceAnchor
    {
        [FameProperty(Name = "source")]
        public String source { get; set; }

    }
}
