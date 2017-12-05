using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("MethodGroup")]
  public class MethodGroup : Group
  {
    [FameProperty(Name = "averageNumberOfInvocations")]    
    public Number averageNumberOfInvocations { get; set; }
    
    [FameProperty(Name = "averageNumberOfLinesOfCode")]    
    public Number averageNumberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "averageNumberOfParameters")]    
    public Number averageNumberOfParameters { get; set; }
    
  }
}
