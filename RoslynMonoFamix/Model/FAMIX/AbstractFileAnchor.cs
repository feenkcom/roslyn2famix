using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AbstractFileAnchor")]
  public class AbstractFileAnchor : FAMIX.SourceAnchor
  {
    [FameProperty(Name = "correspondingFile")]    
    public File correspondingFile { get; set; }
    
    [FameProperty(Name = "encoding")]    
    public String encoding { get; set; }
    
    [FameProperty(Name = "fileName")]    
    public String fileName { get; set; }
    
  }
}
