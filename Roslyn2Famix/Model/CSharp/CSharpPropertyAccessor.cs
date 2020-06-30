using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace CSharp
{
    [FamePackage("CSharp")]
    [FameDescription("CSharpPropertyAccessor")]
    public class CSharpPropertyAccessor : FAMIX.Method
    {
        [FameProperty(Name = "property")]
        public CSharp.CSharpProperty property { get; set; }

    }
}
