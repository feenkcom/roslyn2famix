using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Include")]
  public class Include : Association
  {
    [FameProperty(Name = "source",  Opposite = "outgoingIncludeRelations")]    
    public CFile source { get; set; }
    
    [FameProperty(Name = "target",  Opposite = "incomingIncludeRelations")]    
    public CFile target { get; set; }
    
  }
}
