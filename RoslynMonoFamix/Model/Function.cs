using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Function")]
  public class Function : BehaviouralEntity
  {
    [FameProperty(Name = "container",  Opposite = "functions")]    
    public ContainerEntity container { get; set; }
    
    [FameProperty(Name = "parentModule")]    
    public Module parentModule { get; set; }
    
  }
}
