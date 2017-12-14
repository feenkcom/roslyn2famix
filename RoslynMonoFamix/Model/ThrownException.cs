using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ThrownException")]
  public class ThrownException : Exception
  {
    [FameProperty(Name = "definingMethod",  Opposite = "thrownExceptions")]    
    public Method definingMethod { get; set; }
    
  }
}
