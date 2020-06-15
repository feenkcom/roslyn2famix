using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("CompilationUnit")]
  public class CompilationUnit : FAMIX.CFile
  {
    [FameProperty(Name = "module",  Opposite = "compilationUnit")]    
    public FAMIX.VBModule module { get; set; }
    
  }
}
