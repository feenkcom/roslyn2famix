using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Parameter")]
  public class Parameter : StructuralEntity
  {
    [FameProperty(Name = "parentBehaviouralEntity",  Opposite = "parameters")]    
    public BehaviouralEntity parentBehaviouralEntity { get; set; }
    
  }
}
