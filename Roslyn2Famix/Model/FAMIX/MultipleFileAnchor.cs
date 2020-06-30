using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("MultipleFileAnchor")]
    public class MultipleFileAnchor : FAMIX.SourceAnchor
    {
        private List<FAMIX.AbstractFileAnchor> allFiles = new List<FAMIX.AbstractFileAnchor>();

        [FameProperty(Name = "allFiles")]
        public List<FAMIX.AbstractFileAnchor> AllFiles
        {
            get { return allFiles; }
            set { allFiles = value; }
        }
        public void AddAllFile(FAMIX.AbstractFileAnchor one)
        {
            allFiles.Add(one);
        }

    }
}
