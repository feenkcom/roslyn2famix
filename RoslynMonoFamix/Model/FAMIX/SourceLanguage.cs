using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("SourceLanguage")]
  public class SourceLanguage : FAMIX.Entity
  {
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
    private List<SourcedEntity> sourcedEntities = new List<SourcedEntity>();
    
    [FameProperty(Name = "sourcedEntities",  Opposite = "declaredSourceLanguage")]    
    public List <SourcedEntity> SourcedEntities
    {
      get { return sourcedEntities; }
      set { sourcedEntities = value; }
    }
    public void AddSourcedEntitie(SourcedEntity one)
    {
      sourcedEntities.Add(one);
    }
    
  }
}
