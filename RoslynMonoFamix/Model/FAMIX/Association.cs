using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Association")]
  public class Association : FAMIX.SourcedEntity
  {
    [FameProperty(Name = "to")]    
    public FAMIX.NamedEntity to { get; set; }
    
    [FameProperty(Name = "from")]    
    public FAMIX.NamedEntity from { get; set; }
    
    [FameProperty(Name = "previous",  Opposite = "next")]    
    public FAMIX.Association previous { get; set; }
    
    [FameProperty(Name = "next",  Opposite = "previous")]    
    public FAMIX.Association next { get; set; }
    
  }
}
