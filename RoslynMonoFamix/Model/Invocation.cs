using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Invocation")]
  public class Invocation : Association
  {
    private List<BehaviouralEntity> candidates = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "candidates",  Opposite = "incomingInvocations")]    
    public List Candidates
    {
      get { return Candidates; }
      set { Candidates = value; }
    }
    public void AddBehaviouralEntity(BehaviouralEntity one)
    {
      Candidates.Add(one);
    }
    
    [FameProperty(Name = "receiver",  Opposite = "receivingInvocations")]    
    public NamedEntity receiver { get; set; }
    
    [FameProperty(Name = "signature")]    
    public String signature { get; set; }
    
    [FameProperty(Name = "sender",  Opposite = "outgoingInvocations")]    
    public BehaviouralEntity sender { get; set; }
    
  }
}
