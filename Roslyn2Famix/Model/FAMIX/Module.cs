using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Module")]
    public class Module : FAMIX.ScopingEntity
    {
        [FameProperty(Name = "compilationUnit", Opposite = "module")]
        public FAMIX.CompilationUnit compilationUnit { get; set; }

        [FameProperty(Name = "header", Opposite = "module")]
        public FAMIX.Header header { get; set; }

    }
}
