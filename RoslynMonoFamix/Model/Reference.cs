using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Reference")]
  public class Reference : Association
  {
    [FameProperty(Name = "target",  Opposite = "incomingReferences")]    
    public Type target { get; set; }
    
    [FameProperty(Name = "source",  Opposite = "outgoingReferences")]    
    public BehaviouralEntity source { get; set; }
    
  }
}
