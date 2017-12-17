using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace Moose
{
  [FamePackage("Moose")]
  [FameDescription("Model")]
  public class Model : Moose.AbstractGroup
  {
    [FameProperty(Name = "sourceLanguage")]    
    public FAMIX.SourceLanguage sourceLanguage { get; set; }
    
  }
}
