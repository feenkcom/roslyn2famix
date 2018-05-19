using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace CSharp
{
  [FamePackage("CSharp")]
  [FameDescription("CSharpEvent")]
  public class CSharpEvent : FAMIX.Method
  {
    [FameProperty(Name = "addMethod")]    
    public FAMIX.Method addMethod { get; set; }
    
    [FameProperty(Name = "removeMethod")]    
    public FAMIX.Method removeMethod { get; set; }
    
  }
}
