using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace Dynamix
{
    [FamePackage("Dynamix")]
    [FameDescription("Instance")]
    public class Instance : Dynamix.Reference
    {
        [FameProperty(Name = "type", Opposite = "instances")]
        public FAMIX.Type type { get; set; }

    }
}
