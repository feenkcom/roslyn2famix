using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("DereferencedInvocation")]
  public class DereferencedInvocation : FAMIX.Invocation
  {
    [FameProperty(Name = "referencer",  Opposite = "dereferencedInvocations")]    
    public StructuralEntity referencer { get; set; }
    
  }
}
