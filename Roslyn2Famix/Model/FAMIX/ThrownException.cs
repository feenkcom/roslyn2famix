using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("ThrownException")]
    public class ThrownException : FAMIX.Exception
    {
        [FameProperty(Name = "definingMethod", Opposite = "thrownExceptions")]
        public FAMIX.Method definingMethod { get; set; }

    }
}
