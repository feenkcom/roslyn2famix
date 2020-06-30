using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("CaughtException")]
    public class CaughtException : FAMIX.Exception
    {
        [FameProperty(Name = "definingMethod", Opposite = "caughtExceptions")]
        public FAMIX.Method definingMethod { get; set; }

    }
}
