using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ScopingEntity")]
  public class ScopingEntity : FAMIX.ContainerEntity
  {
    private List<GlobalVariable> globalVariables = new List<GlobalVariable>();
    
    [FameProperty(Name = "globalVariables",  Opposite = "parentScope")]    
    public List <GlobalVariable> GlobalVariables
    {
      get { return globalVariables; }
      set { globalVariables = value; }
    }
    public void AddGlobalVariable(GlobalVariable one)
    {
      globalVariables.Add(one);
    }
    
    [FameProperty(Name = "parentScope",  Opposite = "childScopes")]    
    public ScopingEntity parentScope { get; set; }
    
    private List<ScopingEntity> childScopes = new List<ScopingEntity>();
    
    [FameProperty(Name = "childScopes",  Opposite = "parentScope")]    
    public List <ScopingEntity> ChildScopes
    {
      get { return childScopes; }
      set { childScopes = value; }
    }
    public void AddChildScope(ScopingEntity one)
    {
      childScopes.Add(one);
    }
    
  }
}
