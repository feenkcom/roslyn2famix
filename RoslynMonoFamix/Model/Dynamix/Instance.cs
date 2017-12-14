using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace Dynamix
{
  [FamePackage("Dynamix")]
  [FameDescription("Instance")]
  public class Instance : Dynamix.Reference
  {
    [FameProperty(Name = "type",  Opposite = "instances")]    
    public FAMIX.Type type { get; set; }
    
  }
}
