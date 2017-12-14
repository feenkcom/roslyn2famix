using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("StructuralEntity")]
  public class StructuralEntity : FAMIX.LeafEntity
  {
    private List<FAMIX.DereferencedInvocation> dereferencedInvocations = new List<FAMIX.DereferencedInvocation>();
    
    [FameProperty(Name = "dereferencedInvocations",  Opposite = "referencer")]    
    public List <FAMIX.DereferencedInvocation> DereferencedInvocations
    {
      get { return dereferencedInvocations; }
      set { dereferencedInvocations = value; }
    }
    public void AddDereferencedInvocation(FAMIX.DereferencedInvocation one)
    {
      dereferencedInvocations.Add(one);
    }
    
    private List<FAMIX.Access> incomingAccesses = new List<FAMIX.Access>();
    
    [FameProperty(Name = "incomingAccesses",  Opposite = "variable")]    
    public List <FAMIX.Access> IncomingAccesses
    {
      get { return incomingAccesses; }
      set { incomingAccesses = value; }
    }
    public void AddIncomingAccesse(FAMIX.Access one)
    {
      incomingAccesses.Add(one);
    }
    
    private List<FAMIX.BehaviouralEntity> accessors = new List<FAMIX.BehaviouralEntity>();
    
    [FameProperty(Name = "accessors")]    
    public List <FAMIX.BehaviouralEntity> Accessors
    {
      get { return accessors; }
      set { accessors = value; }
    }
    public void AddAccessor(FAMIX.BehaviouralEntity one)
    {
      accessors.Add(one);
    }
    
    [FameProperty(Name = "declaredType",  Opposite = "structuresWithDeclaredType")]    
    public FAMIX.Type declaredType { get; set; }
    
  }
}
