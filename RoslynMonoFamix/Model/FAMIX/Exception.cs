using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Exception")]
  public class Exception : FAMIX.Entity
  {
    [FameProperty(Name = "exceptionClass",  Opposite = "exceptions")]    
    public Class exceptionClass { get; set; }
    
  }
}
