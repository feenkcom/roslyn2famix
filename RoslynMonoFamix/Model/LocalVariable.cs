using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("LocalVariable")]
  public class LocalVariable : StructuralEntity
  {
    [FameProperty(Name = "parentBehaviouralEntity",  Opposite = "localVariables")]    
    public BehaviouralEntity parentBehaviouralEntity { get; set; }
    
  }
}
