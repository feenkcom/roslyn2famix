using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("SourceAnchor")]
  public class SourceAnchor : Entity
  {
    [FameProperty(Name = "lineCount")]    
    public Number lineCount { get; set; }
    
    [FameProperty(Name = "element",  Opposite = "sourceAnchor")]    
    public SourcedEntity element { get; set; }
    
  }
}
