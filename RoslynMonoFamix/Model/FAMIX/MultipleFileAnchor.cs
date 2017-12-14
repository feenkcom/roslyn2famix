using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("MultipleFileAnchor")]
  public class MultipleFileAnchor : FAMIX.SourceAnchor
  {
    private List<FAMIX.AbstractFileAnchor> allFiles = new List<FAMIX.AbstractFileAnchor>();
    
    [FameProperty(Name = "allFiles")]    
    public List <FAMIX.AbstractFileAnchor> AllFiles
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
