using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Header")]
  public class Header : CFile
  {
    [FameProperty(Name = "module",  Opposite = "header")]    
    public Module module { get; set; }
    
  }
}
