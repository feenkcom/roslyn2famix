using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("AbstractFileAnchor")]
    public class AbstractFileAnchor : FAMIX.SourceAnchor
    {
        [FameProperty(Name = "correspondingFile")]
        public FILE.File correspondingFile { get; set; }

        [FameProperty(Name = "encoding")]
        public String encoding { get; set; }

        [FameProperty(Name = "fileName")]
        public String fileName { get; set; }

    }
}
