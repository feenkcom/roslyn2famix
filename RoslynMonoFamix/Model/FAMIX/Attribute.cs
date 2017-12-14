using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Attribute")]
  public class Attribute : FAMIX.StructuralEntity
  {
    [FameProperty(Name = "hierarchyNestingLevel")]    
    public int hierarchyNestingLevel { get; set; }
    
    [FameProperty(Name = "parentType",  Opposite = "attributes")]    
    public Type parentType { get; set; }
    
    [FameProperty(Name = "numberOfLocalAccesses")]    
    public int numberOfLocalAccesses { get; set; }
    
    [FameProperty(Name = "numberOfAccesses")]    
    public int numberOfAccesses { get; set; }
    
    [FameProperty(Name = "numberOfAccessingClasses")]    
    public int numberOfAccessingClasses { get; set; }
    
    [FameProperty(Name = "numberOfGlobalAccesses")]    
    public int numberOfGlobalAccesses { get; set; }
    
    [FameProperty(Name = "hasClassScope")]    
    public Boolean hasClassScope { get; set; }
    
    [FameProperty(Name = "numberOfAccessingMethods")]    
    public int numberOfAccessingMethods { get; set; }
    
  }
}
