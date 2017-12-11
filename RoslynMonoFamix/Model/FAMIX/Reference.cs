using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Reference")]
  public class Reference : FAMIX.Association
  {
    [FameProperty(Name = "source",  Opposite = "outgoingReferences")]    
    public BehaviouralEntity source { get; set; }
    
    [FameProperty(Name = "target",  Opposite = "incomingReferences")]    
    public Type target { get; set; }
    
  }
}
