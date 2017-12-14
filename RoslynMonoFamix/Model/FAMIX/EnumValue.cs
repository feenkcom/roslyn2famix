using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("EnumValue")]
  public class EnumValue : FAMIX.StructuralEntity
  {
    [FameProperty(Name = "parentEnum",  Opposite = "values")]    
    public Enum parentEnum { get; set; }
    
  }
}
