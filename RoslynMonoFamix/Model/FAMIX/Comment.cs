using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Comment")]
  public class Comment : FAMIX.SourcedEntity
  {
    [FameProperty(Name = "content")]    
    public String content { get; set; }
    
    [FameProperty(Name = "container",  Opposite = "comments")]    
    public FAMIX.SourcedEntity container { get; set; }
    
  }
}
