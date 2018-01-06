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
    
    [FameProperty(Name = "declaredType",  Opposite = "structuresWithDeclaredType")]    
    public FAMIX.Type declaredType { get; set; }
    
  }
}
