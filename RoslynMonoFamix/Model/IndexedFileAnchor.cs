using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("IndexedFileAnchor")]
  public class IndexedFileAnchor : AbstractFileAnchor
  {
    [FameProperty(Name = "endPos")]    
    public Number endPos { get; set; }
    
    [FameProperty(Name = "startPos")]    
    public Number startPos { get; set; }
    
  }
}
