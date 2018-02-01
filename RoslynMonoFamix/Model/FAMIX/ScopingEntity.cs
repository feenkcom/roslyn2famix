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
    [FameProperty(Name = "parentScope",  Opposite = "childScopes")]    
    public FAMIX.ScopingEntity parentScope { get; set; }
    
    private List<FAMIX.GlobalVariable> globalVariables = new List<FAMIX.GlobalVariable>();
    
    [FameProperty(Name = "globalVariables",  Opposite = "parentScope")]    
    public List <FAMIX.GlobalVariable> GlobalVariables
    {
      get { return globalVariables; }
      set { globalVariables = value; }
    }
    public void AddGlobalVariable(FAMIX.GlobalVariable one)
    {
      globalVariables.Add(one);
    }
    
    private List<FAMIX.ScopingEntity> childScopes = new List<FAMIX.ScopingEntity>();
    
    [FameProperty(Name = "childScopes",  Opposite = "parentScope")]    
    public List <FAMIX.ScopingEntity> ChildScopes
    {
      get { return childScopes; }
      set { childScopes = value; }
    }
    public void AddChildScope(FAMIX.ScopingEntity one)
    {
      childScopes.Add(one);
    }
    
  }
}
