using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Include")]
  public class Include : FAMIX.Association
  {
    [FameProperty(Name = "target",  Opposite = "incomingIncludeRelations")]    
    public CFile target { get; set; }
    
    [FameProperty(Name = "source",  Opposite = "outgoingIncludeRelations")]    
    public CFile source { get; set; }
    
  }
}
