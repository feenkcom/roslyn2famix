using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace Moose
{
  [FamePackage("Moose")]
  [FameDescription("PropertyGroup")]
  public class PropertyGroup : Moose.Group
  {
    [FameProperty(Name = "property")]    
    public String property { get; set; }
    
  }
}
