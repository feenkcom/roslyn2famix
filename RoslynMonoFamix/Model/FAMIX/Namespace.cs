using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Namespace")]
  public class Namespace : FAMIX.ScopingEntity
  {
    [FameProperty(Name = "abstractness")]    
    public int abstractness { get; set; }
    
    [FameProperty(Name = "distance")]    
    public int distance { get; set; }
    
    [FameProperty(Name = "instability")]    
    public int instability { get; set; }
    
    [FameProperty(Name = "numberOfMethods")]    
    public int numberOfMethods { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "afferentCoupling")]    
    public int afferentCoupling { get; set; }
    
    [FameProperty(Name = "efferentCoupling")]    
    public int efferentCoupling { get; set; }
    
    [FameProperty(Name = "numberOfClasses")]    
    public int numberOfClasses { get; set; }
    
    [FameProperty(Name = "bunchCohesion")]    
    public int bunchCohesion { get; set; }
    
    [FameProperty(Name = "numberOfAttributes")]    
    public int numberOfAttributes { get; set; }
    
    [FameProperty(Name = "numberOfNonInterfacesClasses")]    
    public int numberOfNonInterfacesClasses { get; set; }
    
  }
}
