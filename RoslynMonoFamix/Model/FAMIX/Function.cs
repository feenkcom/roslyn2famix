using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Function")]
  public class Function : FAMIX.BehaviouralEntity
  {
    [FameProperty(Name = "container",  Opposite = "functions")]    
    public FAMIX.ContainerEntity container { get; set; }
    
    [FameProperty(Name = "parentModule")]    
    public FAMIX.VBModule parentModule { get; set; }
    
  }
}
