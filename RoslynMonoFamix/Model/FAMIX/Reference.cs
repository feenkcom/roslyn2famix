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
    [FameProperty(Name = "target",  Opposite = "incomingReferences")]    
    public FAMIX.Type target { get; set; }
    
    [FameProperty(Name = "source",  Opposite = "outgoingReferences")]    
    public FAMIX.BehaviouralEntity source { get; set; }
    
  }
}
