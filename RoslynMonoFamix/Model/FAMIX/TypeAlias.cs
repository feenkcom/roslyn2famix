using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("TypeAlias")]
  public class TypeAlias : FAMIX.Type
  {
    [FameProperty(Name = "aliasedType",  Opposite = "typeAliases")]    
    public Type aliasedType { get; set; }
    
  }
}
