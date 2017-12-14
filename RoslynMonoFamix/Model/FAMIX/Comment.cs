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
    [FameProperty(Name = "container",  Opposite = "comments")]    
    public SourcedEntity container { get; set; }
    
    [FameProperty(Name = "content")]    
    public String content { get; set; }
    
  }
}
