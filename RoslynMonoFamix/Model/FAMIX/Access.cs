using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Access")]
  public class Access : FAMIX.Association
  {
    [FameProperty(Name = "accessor",  Opposite = "accesses")]    
    public FAMIX.BehaviouralEntity accessor { get; set; }
    
    [FameProperty(Name = "variable",  Opposite = "incomingAccesses")]    
    public FAMIX.StructuralEntity variable { get; set; }
    
    [FameProperty(Name = "isWrite")]    
    public Boolean isWrite { get; set; }
    
  }
}
