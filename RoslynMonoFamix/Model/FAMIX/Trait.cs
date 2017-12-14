using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Trait")]
  public class Trait : FAMIX.Type
  {
    private List<TraitUsage> incomingTraitUsages = new List<TraitUsage>();
    
    [FameProperty(Name = "incomingTraitUsages",  Opposite = "trait")]    
    public List <TraitUsage> IncomingTraitUsages
    {
      get { return incomingTraitUsages; }
      set { incomingTraitUsages = value; }
    }
    public void AddIncomingTraitUsage(TraitUsage one)
    {
      incomingTraitUsages.Add(one);
    }
    
  }
}
