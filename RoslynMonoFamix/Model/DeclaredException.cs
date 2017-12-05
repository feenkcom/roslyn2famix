using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("DeclaredException")]
  public class DeclaredException : Exception
  {
    [FameProperty(Name = "definingMethod",  Opposite = "declaredExceptions")]    
    public Method definingMethod { get; set; }
    
  }
}
