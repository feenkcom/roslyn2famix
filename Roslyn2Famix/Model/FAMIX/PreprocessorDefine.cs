using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("PreprocessorDefine")]
    public class PreprocessorDefine : FAMIX.PreprocessorStatement
    {
        [FameProperty(Name = "macro")]
        public String macro { get; set; }

    }
}
