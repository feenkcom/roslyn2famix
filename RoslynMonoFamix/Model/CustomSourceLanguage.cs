using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("CustomSourceLanguage")]
  public class CustomSourceLanguage : SourceLanguage
  {
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
  }
}
