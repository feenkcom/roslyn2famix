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
    private List<File> containerFiles = new List<File>();
    
    [FameProperty(Name = "containerFiles",  Opposite = "entities")]    
    public List <File> ContainerFiles
    {
      get { return containerFiles; }
      set { containerFiles = value; }
    }
    public void AddContainerFile(File one)
    {
      containerFiles.Add(one);
    }
    
    [FameProperty(Name = "numberOfJavaNullChecks")]    
    public int numberOfJavaNullChecks { get; set; }
    
    [FameProperty(Name = "declaredSourceLanguage",  Opposite = "sourcedEntities")]    
    public SourceLanguage declaredSourceLanguage { get; set; }
    
    private List<Comment> comments = new List<Comment>();
    
    [FameProperty(Name = "comments",  Opposite = "container")]    
    public List <Comment> Comments
    {
      get { return comments; }
      set { comments = value; }
    }
    public void AddComment(Comment one)
    {
      comments.Add(one);
    }
    
    [FameProperty(Name = "numberOfLinesOfCodeWithMoreThanOneCharacter")]    
    public int numberOfLinesOfCodeWithMoreThanOneCharacter { get; set; }
    
    [FameProperty(Name = "sourceAnchor",  Opposite = "element")]    
    public SourceAnchor sourceAnchor { get; set; }
    
  }
}
