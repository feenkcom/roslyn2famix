using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Package")]
  public class Package : FAMIX.ScopingEntity
  {
    [FameProperty(Name = "numberOfClientPackages")]    
    public int numberOfClientPackages { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    private List<FAMIX.NamedEntity> childNamedEntities = new List<FAMIX.NamedEntity>();
    
    [FameProperty(Name = "childNamedEntities",  Opposite = "parentPackage")]    
    public List <FAMIX.NamedEntity> ChildNamedEntities
    {
      get { return childNamedEntities; }
      set { childNamedEntities = value; }
    }
    public void AddChildNamedEntitie(FAMIX.NamedEntity one)
    {
      childNamedEntities.Add(one);
    }
    
    [FameProperty(Name = "numberOfMethods")]    
    public int numberOfMethods { get; set; }
    
  }
}
