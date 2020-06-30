using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Header")]
    public class Header : FAMIX.CFile
    {
        [FameProperty(Name = "module", Opposite = "header")]
        public FAMIX.VBModule module { get; set; }

    }
}
