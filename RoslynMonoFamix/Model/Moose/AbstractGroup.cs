using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace Moose
{
  [FamePackage("Moose")]
  [FameDescription("AbstractGroup")]
  public class AbstractGroup : Moose.Entity
  {
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "numberOfPackages")]    
    public int numberOfPackages { get; set; }
    
    [FameProperty(Name = "numberOfAssociations")]    
    public int numberOfAssociations { get; set; }
    
    [FameProperty(Name = "numberOfEntities")]    
    public int numberOfEntities { get; set; }
    
    [FameProperty(Name = "numberOfItems")]    
    public int numberOfItems { get; set; }
    
  }
}
