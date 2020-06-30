using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("DeclaredException")]
    public class DeclaredException : FAMIX.Exception
    {
        [FameProperty(Name = "definingMethod", Opposite = "declaredExceptions")]
        public FAMIX.Method definingMethod { get; set; }

    }
}
