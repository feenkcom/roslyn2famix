using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
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
