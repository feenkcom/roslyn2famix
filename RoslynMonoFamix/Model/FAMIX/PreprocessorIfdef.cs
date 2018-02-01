using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("PreprocessorIfdef")]
  public class PreprocessorIfdef : FAMIX.PreprocessorStatement
  {
    [FameProperty(Name = "macro")]    
    public String macro { get; set; }
    
    [FameProperty(Name = "negated")]    
    public Boolean negated { get; set; }
    
  }
}
