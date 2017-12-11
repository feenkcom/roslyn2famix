using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("CaughtException")]
  public class CaughtException : FAMIX.Exception
  {
    [FameProperty(Name = "definingMethod",  Opposite = "caughtExceptions")]    
    public Method definingMethod { get; set; }
    
  }
}
