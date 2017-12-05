using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("TypeGroup")]
  public class TypeGroup : Group
  {
    [FameProperty(Name = "averageNumberOfAttributes")]    
    public Number averageNumberOfAttributes { get; set; }
    
    [FameProperty(Name = "distance")]    
    public Number distance { get; set; }
    
    [FameProperty(Name = "instability")]    
    public Number instability { get; set; }
    
    [FameProperty(Name = "averageNumberOfStatements")]    
    public Number averageNumberOfStatements { get; set; }
    
    [FameProperty(Name = "efferentCoupling")]    
    public Number efferentCoupling { get; set; }
    
    [FameProperty(Name = "averageNumberOfMethods")]    
    public Number averageNumberOfMethods { get; set; }
    
    [FameProperty(Name = "abstractness")]    
    public Number abstractness { get; set; }
    
    [FameProperty(Name = "afferentCoupling")]    
    public Number afferentCoupling { get; set; }
    
    [FameProperty(Name = "bunchCohesion")]    
    public Number bunchCohesion { get; set; }
    
    [FameProperty(Name = "averageNumberOfMethods")]    
    public Number averageNumberOfMethods { get; set; }
    
  }
}
