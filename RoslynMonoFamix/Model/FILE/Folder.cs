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
    
    [FameProperty(Name = "numberOfFiles")]    
    public int numberOfFiles { get; set; }
    
    [FameProperty(Name = "numberOfFolders")]    
    public int numberOfFolders { get; set; }
    
    [FameProperty(Name = "totalNumberOfLinesOfText")]    
    public int totalNumberOfLinesOfText { get; set; }
    
    [FameProperty(Name = "numberOfEmptyLinesOfText")]    
    public int numberOfEmptyLinesOfText { get; set; }
    
  }
}
