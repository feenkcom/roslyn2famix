using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("PreprocessorIfdef")]
  public class PreprocessorIfdef : PreprocessorStatement
  {
    [FameProperty(Name = "macro")]    
    public String macro { get; set; }
    
    [FameProperty(Name = "negated")]    
    public Boolean negated { get; set; }
    
  }
}
