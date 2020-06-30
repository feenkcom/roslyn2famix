using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
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
