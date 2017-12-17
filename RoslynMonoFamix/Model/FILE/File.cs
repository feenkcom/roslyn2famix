using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FILE
{
  [FamePackage("FILE")]
  [FameDescription("File")]
  public class File : FILE.AbstractFile
  {
    private List<FAMIX.SourcedEntity> entities = new List<FAMIX.SourcedEntity>();
    
    [FameProperty(Name = "entities",  Opposite = "containerFiles")]    
    public List <FAMIX.SourcedEntity> Entities
    {
      get { return entities; }
      set { entities = value; }
    }
    public void AddEntitie(FAMIX.SourcedEntity one)
    {
      entities.Add(one);
    }
    
  }
}
