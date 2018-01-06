using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Method")]
  public class Method : FAMIX.BehaviouralEntity
  {
    [FameProperty(Name = "isConstructor")]    
    public Boolean isConstructor { get; set; }
    
    [FameProperty(Name = "hasClassScope")]    
    public Boolean hasClassScope { get; set; }
    
    [FameProperty(Name = "kind")]    
    public String kind { get; set; }
    
    [FameProperty(Name = "hierarchyNestingLevel")]    
    public int hierarchyNestingLevel { get; set; }
    
    [FameProperty(Name = "timeStamp")]    
    public String timeStamp { get; set; }
    
    [FameProperty(Name = "parentType",  Opposite = "methods")]    
    public FAMIX.Type parentType { get; set; }
    
    [FameProperty(Name = "category")]    
    public String category { get; set; }
    
  }
}
