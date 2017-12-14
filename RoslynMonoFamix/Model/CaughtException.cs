using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("CaughtException")]
  public class CaughtException : Exception
  {
    [FameProperty(Name = "definingMethod",  Opposite = "caughtExceptions")]    
    public Method definingMethod { get; set; }
    
  }
}
