using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("IndexedFileAnchor")]
  public class IndexedFileAnchor : FAMIX.AbstractFileAnchor
  {
    [FameProperty(Name = "startPos")]    
    public int startPos { get; set; }
    
    [FameProperty(Name = "endPos")]    
    public int endPos { get; set; }
    
  }
}
