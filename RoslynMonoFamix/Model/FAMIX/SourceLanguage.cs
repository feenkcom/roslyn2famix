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
    private List<FAMIX.SourcedEntity> sourcedEntities = new List<FAMIX.SourcedEntity>();
    
    [FameProperty(Name = "sourcedEntities",  Opposite = "declaredSourceLanguage")]    
    public List <FAMIX.SourcedEntity> SourcedEntities
    {
      get { return sourcedEntities; }
      set { sourcedEntities = value; }
    }
    public void AddSourcedEntitie(FAMIX.SourcedEntity one)
    {
      sourcedEntities.Add(one);
    }
    
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
  }
}
