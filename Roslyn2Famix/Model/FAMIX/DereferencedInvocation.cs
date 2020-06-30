using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("DereferencedInvocation")]
    public class DereferencedInvocation : FAMIX.Invocation
    {
        [FameProperty(Name = "referencer", Opposite = "dereferencedInvocations")]
        public FAMIX.StructuralEntity referencer { get; set; }

    }
}
