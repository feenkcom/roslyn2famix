using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Module")]
  public class Module : ScopingEntity
  {
    [FameProperty(Name = "header",  Opposite = "module")]    
    public Header header { get; set; }
    
    [FameProperty(Name = "compilationUnit",  Opposite = "module")]    
    public CompilationUnit compilationUnit { get; set; }
    
  }
}
