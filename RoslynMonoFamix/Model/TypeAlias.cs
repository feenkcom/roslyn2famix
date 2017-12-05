using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("TypeAlias")]
  public class TypeAlias : Type
  {
    [FameProperty(Name = "aliasedType",  Opposite = "typeAliases")]    
    public Type aliasedType { get; set; }
    
  }
}
