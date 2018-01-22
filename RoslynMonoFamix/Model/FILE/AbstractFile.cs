using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FILE
{
  [FamePackage("FILE")]
  [FameDescription("AbstractFile")]
  public class AbstractFile : FAMIX.Entity
  {
    [FameProperty(Name = "parentFolder",  Opposite = "childrenFileSystemEntities")]    
    public FILE.Folder parentFolder { get; set; }
    
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
  }
}
