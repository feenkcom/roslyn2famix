using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ScopingEntity")]
  public class ScopingEntity : ContainerEntity
  {
    private List<GlobalVariable> globalVariables = new List<GlobalVariable>();
    
    [FameProperty(Name = "globalVariables",  Opposite = "parentScope")]    
    public List GlobalVariables
    {
      { return GlobalVariables; }
      { GlobalVariables = value; }
    }
    public void AddGlobalVariable(GlobalVariable one)
    {
      GlobalVariables.Add(one);
    }
    
    [FameProperty(Name = "parentScope",  Opposite = "childScopes")]    
    public ScopingEntity parentScope { get; set; }
    
    private List<ScopingEntity> childScopes = new List<ScopingEntity>();
    
    [FameProperty(Name = "childScopes",  Opposite = "parentScope")]    
    public List ChildScopes
    {
      { return ChildScopes; }
      { ChildScopes = value; }
    }
    public void AddScopingEntity(ScopingEntity one)
    {
      ChildScopes.Add(one);
    }
    
  }
}
