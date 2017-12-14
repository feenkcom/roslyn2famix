using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ImplicitVariable")]
  public class ImplicitVariable : FAMIX.StructuralEntity
  {
    [FameProperty(Name = "parentBehaviouralEntity",  Opposite = "implicitVariables")]    
    public FAMIX.BehaviouralEntity parentBehaviouralEntity { get; set; }
    
  }
}
