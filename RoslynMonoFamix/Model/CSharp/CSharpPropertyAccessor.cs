using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
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
