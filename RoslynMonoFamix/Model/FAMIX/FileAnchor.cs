using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("FileAnchor")]
  public class FileAnchor : FAMIX.AbstractFileAnchor
  {
    [FameProperty(Name = "startLine")]    
    public int startLine { get; set; }
    
    [FameProperty(Name = "endLine")]    
    public int endLine { get; set; }
    
    [FameProperty(Name = "endColumn")]    
    public int endColumn { get; set; }
    
    [FameProperty(Name = "startColumn")]    
    public int startColumn { get; set; }
    
  }
}
