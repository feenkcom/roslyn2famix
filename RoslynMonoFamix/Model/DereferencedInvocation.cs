using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("DereferencedInvocation")]
  public class DereferencedInvocation : Invocation
  {
    [FameProperty(Name = "referencer",  Opposite = "dereferencedInvocations")]    
    public StructuralEntity referencer { get; set; }
    
  }
}
