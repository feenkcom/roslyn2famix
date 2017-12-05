using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ImplicitVariable")]
  public class ImplicitVariable : StructuralEntity
  {
    [FameProperty(Name = "parentBehaviouralEntity",  Opposite = "implicitVariables")]    
    public BehaviouralEntity parentBehaviouralEntity { get; set; }
    
  }
}
