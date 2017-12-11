using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("SourceTextAnchor")]
  public class SourceTextAnchor : FAMIX.SourceAnchor
  {
    [FameProperty(Name = "source")]    
    public String source { get; set; }
    
  }
}
