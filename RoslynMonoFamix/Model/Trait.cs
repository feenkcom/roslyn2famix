using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Trait")]
  public class Trait : Type
  {
    private List<TraitUsage> incomingTraitUsages = new List<TraitUsage>();
    
    [FameProperty(Name = "incomingTraitUsages",  Opposite = "trait")]    
    public List IncomingTraitUsages
    {
      get { return IncomingTraitUsages; }
      set { IncomingTraitUsages = value; }
    }
    public void AddTraitUsage(TraitUsage one)
    {
      IncomingTraitUsages.Add(one);
    }
    
  }
}
