using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FILE
{
  [FamePackage("FILE")]
  [FameDescription("Folder")]
  public class Folder : FILE.AbstractFile
  {
    private List<FILE.AbstractFile> childrenFileSystemEntities = new List<FILE.AbstractFile>();
    
    [FameProperty(Name = "childrenFileSystemEntities",  Opposite = "parentFolder")]    
    public List <FILE.AbstractFile> ChildrenFileSystemEntities
    {
      get { return childrenFileSystemEntities; }
      set { childrenFileSystemEntities = value; }
    }
    public void AddChildrenFileSystemEntitie(FILE.AbstractFile one)
    {
      childrenFileSystemEntities.Add(one);
    }
    
  }
}
