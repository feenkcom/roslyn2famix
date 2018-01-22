using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("NamedEntity")]
  public class NamedEntity : FAMIX.SourcedEntity
  {
    [FameProperty(Name = "nameLength")]    
    public int nameLength { get; set; }
    
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
    [FameProperty(Name = "isPackage")]    
    public Boolean isPackage { get; set; }
    
    [FameProperty(Name = "isFinal")]    
    public Boolean isFinal { get; set; }
    
    [FameProperty(Name = "parentPackage",  Opposite = "childNamedEntities")]    
    public FAMIX.Package parentPackage { get; set; }
    
    [FameProperty(Name = "isPrivate")]    
    public Boolean isPrivate { get; set; }
    
    [FameProperty(Name = "isProtected")]    
    public Boolean isProtected { get; set; }
    
    private List<String> modifiers = new List<String>();
    
    [FameProperty(Name = "modifiers")]    
    public List <String> Modifiers
    {
      get { return modifiers; }
      set { modifiers = value; }
    }
    public void AddModifier(String one)
    {
      modifiers.Add(one);
    }
    
    [FameProperty(Name = "isAbstract")]    
    public Boolean isAbstract { get; set; }
    
    [FameProperty(Name = "isPublic")]    
    public Boolean isPublic { get; set; }
    
    [FameProperty(Name = "isStub")]    
    public Boolean isStub { get; set; }
    
    private List<FAMIX.Invocation> receivingInvocations = new List<FAMIX.Invocation>();
    
    [FameProperty(Name = "receivingInvocations",  Opposite = "receiver")]    
    public List <FAMIX.Invocation> ReceivingInvocations
    {
      get { return receivingInvocations; }
      set { receivingInvocations = value; }
    }
    public void AddReceivingInvocation(FAMIX.Invocation one)
    {
      receivingInvocations.Add(one);
    }
    
  }
}
