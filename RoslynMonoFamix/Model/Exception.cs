using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Exception")]
  public class Exception : Entity
  {
    [FameProperty(Name = "exceptionClass",  Opposite = "exceptions")]    
    public Class exceptionClass { get; set; }
    
  }
}
