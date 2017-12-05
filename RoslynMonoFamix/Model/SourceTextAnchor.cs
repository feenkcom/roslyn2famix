using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("SourceTextAnchor")]
  public class SourceTextAnchor : SourceAnchor
  {
    [FameProperty(Name = "source")]    
    public String source { get; set; }
    
  }
}
