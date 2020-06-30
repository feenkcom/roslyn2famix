using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace CSharp
{
    [FamePackage("CSharp")]
    [FameDescription("CSharpProperty")]
    public class CSharpProperty : FAMIX.Attribute
    {
        [FameProperty(Name = "getter")]
        public CSharp.CSharpPropertyAccessor getter { get; set; }

        [FameProperty(Name = "setter")]
        public CSharp.CSharpPropertyAccessor setter { get; set; }

    }
}
