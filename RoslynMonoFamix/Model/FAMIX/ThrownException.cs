using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ThrownException")]
  public class ThrownException : FAMIX.Exception
  {
    [FameProperty(Name = "definingMethod",  Opposite = "thrownExceptions")]    
    public FAMIX.Method definingMethod { get; set; }
    
  }
}
