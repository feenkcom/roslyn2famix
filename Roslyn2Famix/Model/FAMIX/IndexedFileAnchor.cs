using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("IndexedFileAnchor")]
    public class IndexedFileAnchor : FAMIX.AbstractFileAnchor
    {
        [FameProperty(Name = "endPos")]
        public int endPos { get; set; }

        [FameProperty(Name = "startPos")]
        public int startPos { get; set; }

    }
}
