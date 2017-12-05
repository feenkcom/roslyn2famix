using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("PreprocessorDefine")]
  public class PreprocessorDefine : PreprocessorStatement
  {
    [FameProperty(Name = "macro")]    
    public String macro { get; set; }
    
  }
}
