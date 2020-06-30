using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FILE
{
    [FamePackage("FILE")]
    [FameDescription("AbstractFile")]
    public class AbstractFile : FAMIX.Entity
    {
        [FameProperty(Name = "name")]
        public String name { get; set; }

        [FameProperty(Name = "parentFolder", Opposite = "childrenFileSystemEntities")]
        public FILE.Folder parentFolder { get; set; }

    }
}
