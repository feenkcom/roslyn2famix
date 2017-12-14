using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace Moose
{
  [FamePackage("Moose")]
  [FameDescription("Model")]
  public class Model : Moose.AbstractGroup
  {
    [FameProperty(Name = "numberOfClasses")]    
    public int numberOfClasses { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCodePerMethod")]    
    public int numberOfLinesOfCodePerMethod { get; set; }
    
    [FameProperty(Name = "numberOfModelClasses")]    
    public int numberOfModelClasses { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCodePerPackage")]    
    public int numberOfLinesOfCodePerPackage { get; set; }
    
    [FameProperty(Name = "numberOfModelMethods")]    
    public int numberOfModelMethods { get; set; }
    
    [FameProperty(Name = "numberOfMethodsPerPackage")]    
    public int numberOfMethodsPerPackage { get; set; }
    
    [FameProperty(Name = "averageCyclomaticComplexity")]    
    public int averageCyclomaticComplexity { get; set; }
    
    [FameProperty(Name = "sourceLanguage")]    
    public FAMIX.SourceLanguage sourceLanguage { get; set; }
    
    [FameProperty(Name = "numberOfClassesPerPackage")]    
    public int numberOfClassesPerPackage { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCodePerClass")]    
    public int numberOfLinesOfCodePerClass { get; set; }
    
    [FameProperty(Name = "numberOfMethods")]    
    public int numberOfMethods { get; set; }
    
  }
}
