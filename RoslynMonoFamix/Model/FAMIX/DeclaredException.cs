using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("DeclaredException")]
  public class DeclaredException : FAMIX.Exception
  {
    [FameProperty(Name = "definingMethod",  Opposite = "declaredExceptions")]    
    public FAMIX.Method definingMethod { get; set; }
    
  }
}
