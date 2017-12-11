using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Inheritance")]
  public class Inheritance : FAMIX.Association
  {
    [FameProperty(Name = "superclass",  Opposite = "subInheritances")]    
    public Type superclass { get; set; }
    
    [FameProperty(Name = "subclass",  Opposite = "superInheritances")]    
    public Type subclass { get; set; }
    
  }
}
