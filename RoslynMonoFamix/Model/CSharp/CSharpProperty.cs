using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
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
