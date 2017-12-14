using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("SourceAnchor")]
  public class SourceAnchor : FAMIX.Entity
  {
    [FameProperty(Name = "element",  Opposite = "sourceAnchor")]    
    public SourcedEntity element { get; set; }
    
    [FameProperty(Name = "lineCount")]    
    public int lineCount { get; set; }
    
  }
}
