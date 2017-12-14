using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("MethodGroup")]
  public class MethodGroup : Moose.Group
  {
    [FameProperty(Name = "averageNumberOfInvocations")]    
    public int averageNumberOfInvocations { get; set; }
    
    [FameProperty(Name = "averageNumberOfParameters")]    
    public int averageNumberOfParameters { get; set; }
    
    [FameProperty(Name = "averageNumberOfLinesOfCode")]    
    public int averageNumberOfLinesOfCode { get; set; }
    
  }
}
