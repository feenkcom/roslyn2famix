using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("TypeAlias")]
    public class TypeAlias : FAMIX.Type
    {
        [FameProperty(Name = "aliasedType", Opposite = "typeAliases")]
        public FAMIX.Type aliasedType { get; set; }

    }
}
