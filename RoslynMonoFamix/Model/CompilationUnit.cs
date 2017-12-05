using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("CompilationUnit")]
  public class CompilationUnit : CFile
  {
    [FameProperty(Name = "module",  Opposite = "compilationUnit")]    
    public Module module { get; set; }
    
  }
}
