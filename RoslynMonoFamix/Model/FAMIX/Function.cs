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
    [FameProperty(Name = "parentModule")]    
    public Module parentModule { get; set; }
    
    [FameProperty(Name = "container",  Opposite = "functions")]    
    public ContainerEntity container { get; set; }
    
  }
}
