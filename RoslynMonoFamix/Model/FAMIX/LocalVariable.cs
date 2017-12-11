using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("LocalVariable")]
  public class LocalVariable : FAMIX.StructuralEntity
  {
    [FameProperty(Name = "parentBehaviouralEntity",  Opposite = "localVariables")]    
    public BehaviouralEntity parentBehaviouralEntity { get; set; }
    
  }
}
