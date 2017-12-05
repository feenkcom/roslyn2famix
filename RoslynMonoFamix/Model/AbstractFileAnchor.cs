using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AbstractFileAnchor")]
  public class AbstractFileAnchor : SourceAnchor
  {
    [FameProperty(Name = "correspondingFile")]    
    public File correspondingFile { get; set; }
    
    [FameProperty(Name = "encoding")]    
    public String encoding { get; set; }
    
    [FameProperty(Name = "fileName")]    
    public String fileName { get; set; }
    
  }
}
