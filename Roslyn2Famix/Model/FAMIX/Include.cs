using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Include")]
    public class Include : FAMIX.Association
    {
        [FameProperty(Name = "source", Opposite = "outgoingIncludeRelations")]
        public FAMIX.CFile source { get; set; }

        [FameProperty(Name = "target", Opposite = "incomingIncludeRelations")]
        public FAMIX.CFile target { get; set; }

    }
}
