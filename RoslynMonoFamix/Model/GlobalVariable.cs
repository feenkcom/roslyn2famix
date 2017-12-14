using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("GlobalVariable")]
  public class GlobalVariable : StructuralEntity
  {
    [FameProperty(Name = "parentScope",  Opposite = "globalVariables")]    
    public ScopingEntity parentScope { get; set; }
    
    [FameProperty(Name = "parentModule")]    
    public Module parentModule { get; set; }
    
  }
}
