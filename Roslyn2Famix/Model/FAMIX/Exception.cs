using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Exception")]
    public class Exception : FAMIX.Entity
    {
        [FameProperty(Name = "exceptionClass", Opposite = "exceptions")]
        public FAMIX.Class exceptionClass { get; set; }

    }
}
