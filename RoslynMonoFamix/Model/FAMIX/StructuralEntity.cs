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
    private List<BehaviouralEntity> accessors = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "accessors")]    
    public List <BehaviouralEntity> Accessors
    {
      get { return accessors; }
      set { accessors = value; }
    }
    public void AddAccessor(BehaviouralEntity one)
    {
      accessors.Add(one);
    }
    
    [FameProperty(Name = "declaredType",  Opposite = "structuresWithDeclaredType")]    
    public Type declaredType { get; set; }
    
    private List<DereferencedInvocation> dereferencedInvocations = new List<DereferencedInvocation>();
    
    [FameProperty(Name = "dereferencedInvocations",  Opposite = "referencer")]    
    public List <DereferencedInvocation> DereferencedInvocations
    {
      get { return dereferencedInvocations; }
      set { dereferencedInvocations = value; }
    }
    public void AddDereferencedInvocation(DereferencedInvocation one)
    {
      dereferencedInvocations.Add(one);
    }
    
    private List<Access> incomingAccesses = new List<Access>();
    
    [FameProperty(Name = "incomingAccesses",  Opposite = "variable")]    
    public List <Access> IncomingAccesses
    {
      get { return incomingAccesses; }
      set { incomingAccesses = value; }
    }
    public void AddIncomingAccesse(Access one)
    {
      incomingAccesses.Add(one);
    }
    
  }
}
