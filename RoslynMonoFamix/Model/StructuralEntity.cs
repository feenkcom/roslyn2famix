using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("StructuralEntity")]
  public class StructuralEntity : LeafEntity
  {
    private List<DereferencedInvocation> dereferencedInvocations = new List<DereferencedInvocation>();
    
    [FameProperty(Name = "dereferencedInvocations",  Opposite = "referencer")]    
    public List DereferencedInvocations
    {
      get { return DereferencedInvocations; }
      set { DereferencedInvocations = value; }
    }
    public void AddDereferencedInvocation(DereferencedInvocation one)
    {
      DereferencedInvocations.Add(one);
    }
    
    [FameProperty(Name = "declaredType",  Opposite = "structuresWithDeclaredType")]    
    public Type declaredType { get; set; }
    
    private List<Access> incomingAccesses = new List<Access>();
    
    [FameProperty(Name = "incomingAccesses",  Opposite = "variable")]    
    public List IncomingAccesses
    {
      get { return IncomingAccesses; }
      set { IncomingAccesses = value; }
    }
    public void AddAccess(Access one)
    {
      IncomingAccesses.Add(one);
    }
    
    private List<BehaviouralEntity> accessors = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "accessors")]    
    public List Accessors
    {
      get { return Accessors; }
      set { Accessors = value; }
    }
    public void AddBehaviouralEntity(BehaviouralEntity one)
    {
      Accessors.Add(one);
    }
    
  }
}
