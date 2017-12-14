using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("TraitUsage")]
  public class TraitUsage : FAMIX.Association
  {
    [FameProperty(Name = "user",  Opposite = "outgoingTraitUsages")]    
    public Type user { get; set; }
    
    [FameProperty(Name = "trait",  Opposite = "incomingTraitUsages")]    
    public Trait trait { get; set; }
    
  }
}
