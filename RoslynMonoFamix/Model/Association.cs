using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Association")]
  public class Association : SourcedEntity
  {
    [FameProperty(Name = "next",  Opposite = "previous")]    
    public Association next { get; set; }
    
    [FameProperty(Name = "previous",  Opposite = "next")]    
    public Association previous { get; set; }
    
    [FameProperty(Name = "to")]    
    public NamedEntity to { get; set; }
    
    [FameProperty(Name = "from")]    
    public NamedEntity from { get; set; }
    
  }
}
