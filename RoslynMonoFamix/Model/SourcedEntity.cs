using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("SourcedEntity")]
  public class SourcedEntity : Entity
  {
    private List<File> containerFiles = new List<File>();
    
    [FameProperty(Name = "containerFiles",  Opposite = "entities")]    
    public List ContainerFiles
    {
      { return ContainerFiles; }
      { ContainerFiles = value; }
    }
    public void AddFile(File one)
    {
      ContainerFiles.Add(one);
    }
    
    [FameProperty(Name = "declaredSourceLanguage",  Opposite = "sourcedEntities")]    
    public SourceLanguage declaredSourceLanguage { get; set; }
    
    private List<Comment> comments = new List<Comment>();
    
    [FameProperty(Name = "comments",  Opposite = "container")]    
    public List Comments
    {
      { return Comments; }
      { Comments = value; }
    }
    public void AddComment(Comment one)
    {
      Comments.Add(one);
    }
    
    [FameProperty(Name = "sourceAnchor",  Opposite = "element")]    
    public SourceAnchor sourceAnchor { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCodeWithMoreThanOneCharacter")]    
    public Number numberOfLinesOfCodeWithMoreThanOneCharacter { get; set; }
    
    [FameProperty(Name = "numberOfJavaNullChecks")]    
    public Number numberOfJavaNullChecks { get; set; }
    
  }
}
