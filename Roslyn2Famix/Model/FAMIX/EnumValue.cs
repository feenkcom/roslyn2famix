using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("EnumValue")]
    public class EnumValue : FAMIX.StructuralEntity
    {
        [FameProperty(Name = "parentEnum", Opposite = "values")]
        public FAMIX.Enum parentEnum { get; set; }

    }
}
