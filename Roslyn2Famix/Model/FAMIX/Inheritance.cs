using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Inheritance")]
    public class Inheritance : FAMIX.Association
    {
        [FameProperty(Name = "subclass", Opposite = "superInheritances")]
        public FAMIX.Type subclass { get; set; }

        [FameProperty(Name = "superclass", Opposite = "subInheritances")]
        public FAMIX.Type superclass { get; set; }

    }
}
