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
    private List<FAMIX.TraitUsage> incomingTraitUsages = new List<FAMIX.TraitUsage>();
    
    [FameProperty(Name = "incomingTraitUsages",  Opposite = "trait")]    
    public List <FAMIX.TraitUsage> IncomingTraitUsages
    {
      get { return incomingTraitUsages; }
      set { incomingTraitUsages = value; }
    }
    public void AddIncomingTraitUsage(FAMIX.TraitUsage one)
    {
      incomingTraitUsages.Add(one);
    }
    
  }
}
