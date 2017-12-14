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
    [FameProperty(Name = "propertyTotalOriginal")]    
    public int propertyTotalOriginal { get; set; }
    
    [FameProperty(Name = "sizeOriginal")]    
    public int sizeOriginal { get; set; }
    
    [FameProperty(Name = "propertyTotal")]    
    public int propertyTotal { get; set; }
    
    [FameProperty(Name = "sizeRatio")]    
    public int sizeRatio { get; set; }
    
    [FameProperty(Name = "property")]    
    public String property { get; set; }
    
    [FameProperty(Name = "propertyRatio")]    
    public int propertyRatio { get; set; }
    
  }
}
