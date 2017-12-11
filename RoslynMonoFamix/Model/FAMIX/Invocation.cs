using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Invocation")]
  public class Invocation : FAMIX.Association
  {
    [FameProperty(Name = "signature")]    
    public String signature { get; set; }
    
    [FameProperty(Name = "sender",  Opposite = "outgoingInvocations")]    
    public BehaviouralEntity sender { get; set; }
    
    private List<BehaviouralEntity> candidates = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "candidates",  Opposite = "incomingInvocations")]    
    public List <BehaviouralEntity> Candidates
    {
      get { return candidates; }
      set { candidates = value; }
    }
    public void AddCandidate(BehaviouralEntity one)
    {
      candidates.Add(one);
    }
    
    [FameProperty(Name = "receiver",  Opposite = "receivingInvocations")]    
    public NamedEntity receiver { get; set; }
    
  }
}
