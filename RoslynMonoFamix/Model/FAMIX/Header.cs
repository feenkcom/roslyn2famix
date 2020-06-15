using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Header")]
  public class Header : FAMIX.CFile
  {
    [FameProperty(Name = "module",  Opposite = "header")]    
    public FAMIX.VBModule module { get; set; }
    
  }
}
