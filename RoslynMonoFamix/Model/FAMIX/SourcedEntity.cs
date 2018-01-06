using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("SourcedEntity")]
  public class SourcedEntity : FAMIX.Entity
  {
    [FameProperty(Name = "declaredSourceLanguage",  Opposite = "sourcedEntities")]    
    public FAMIX.SourceLanguage declaredSourceLanguage { get; set; }
    
    private List<FAMIX.Comment> comments = new List<FAMIX.Comment>();
    
    [FameProperty(Name = "comments",  Opposite = "container")]    
    public List <FAMIX.Comment> Comments
    {
      get { return comments; }
      set { comments = value; }
    }
    public void AddComment(FAMIX.Comment one)
    {
      comments.Add(one);
    }
    
    private List<FILE.File> containerFiles = new List<FILE.File>();
    
    [FameProperty(Name = "containerFiles",  Opposite = "entities")]    
    public List <FILE.File> ContainerFiles
    {
      get { return containerFiles; }
      set { containerFiles = value; }
    }
    public void AddContainerFile(FILE.File one)
    {
      containerFiles.Add(one);
    }
    
    [FameProperty(Name = "sourceAnchor",  Opposite = "element")]    
    public FAMIX.SourceAnchor sourceAnchor { get; set; }
    
  }
}
