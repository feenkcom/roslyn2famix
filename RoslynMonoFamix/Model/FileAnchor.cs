using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("FileAnchor")]
  public class FileAnchor : AbstractFileAnchor
  {
    [FameProperty(Name = "startColumn")]    
    public Number startColumn { get; set; }
    
    [FameProperty(Name = "startLine")]    
    public Number startLine { get; set; }
    
    [FameProperty(Name = "endLine")]    
    public Number endLine { get; set; }
    
    [FameProperty(Name = "endColumn")]    
    public Number endColumn { get; set; }
    
  }
}
