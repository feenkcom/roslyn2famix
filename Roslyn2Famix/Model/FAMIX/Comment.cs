using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Comment")]
    public class Comment : FAMIX.SourcedEntity
    {
        [FameProperty(Name = "container", Opposite = "comments")]
        public FAMIX.SourcedEntity container { get; set; }

        [FameProperty(Name = "content")]
        public String content { get; set; }

    }
}
