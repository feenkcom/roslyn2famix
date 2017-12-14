using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("PreprocessorDefine")]
  public class PreprocessorDefine : FAMIX.PreprocessorStatement
  {
    [FameProperty(Name = "macro")]    
    public String macro { get; set; }
    
  }
}
