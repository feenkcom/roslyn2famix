using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("CustomSourceLanguage")]
  public class CustomSourceLanguage : FAMIX.SourceLanguage
  {
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
  }
}
