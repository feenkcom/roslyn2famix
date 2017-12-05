using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("SourceLanguage")]
  public class SourceLanguage : Entity
  {
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
    private List<SourcedEntity> sourcedEntities = new List<SourcedEntity>();
    
    [FameProperty(Name = "sourcedEntities",  Opposite = "declaredSourceLanguage")]    
    public List SourcedEntities
    {
      { return SourcedEntities; }
      { SourcedEntities = value; }
    }
    public void AddSourcedEntity(SourcedEntity one)
    {
      SourcedEntities.Add(one);
    }
    
  }
}
