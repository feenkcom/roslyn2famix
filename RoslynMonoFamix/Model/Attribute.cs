using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Attribute")]
  public class Attribute : StructuralEntity
  {
    [FameProperty(Name = "hierarchyNestingLevel")]    
    public Number hierarchyNestingLevel { get; set; }
    
    [FameProperty(Name = "numberOfAccessingClasses")]    
    public Number numberOfAccessingClasses { get; set; }
    
    [FameProperty(Name = "numberOfAccessingMethods")]    
    public Number numberOfAccessingMethods { get; set; }
    
    [FameProperty(Name = "hasClassScope")]    
    public Boolean hasClassScope { get; set; }
    
    [FameProperty(Name = "numberOfGlobalAccesses")]    
    public Number numberOfGlobalAccesses { get; set; }
    
    [FameProperty(Name = "parentType",  Opposite = "attributes")]    
    public Type parentType { get; set; }
    
    [FameProperty(Name = "numberOfLocalAccesses")]    
    public Number numberOfLocalAccesses { get; set; }
    
    [FameProperty(Name = "numberOfAccesses")]    
    public Number numberOfAccesses { get; set; }
    
  }
}
