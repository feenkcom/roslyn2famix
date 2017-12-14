using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("TypeGroup")]
  public class TypeGroup : Moose.Group
  {
    [FameProperty(Name = "averageNumberOfMethods")]    
    public int averageNumberOfMethods { get; set; }
    
    [FameProperty(Name = "averageNumberOfLinesOfCode")]    
    public int averageNumberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "distance")]    
    public int distance { get; set; }
    
    [FameProperty(Name = "efferentCoupling")]    
    public int efferentCoupling { get; set; }
    
    [FameProperty(Name = "averageNumberOfAttributes")]    
    public int averageNumberOfAttributes { get; set; }
    
    [FameProperty(Name = "afferentCoupling")]    
    public int afferentCoupling { get; set; }
    
    [FameProperty(Name = "instability")]    
    public int instability { get; set; }
    
    [FameProperty(Name = "abstractness")]    
    public int abstractness { get; set; }
    
    [FameProperty(Name = "bunchCohesion")]    
    public int bunchCohesion { get; set; }
    
    [FameProperty(Name = "averageNumberOfStatements")]    
    public int averageNumberOfStatements { get; set; }
    
  }
}
