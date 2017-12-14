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
    private List<AbstractFileAnchor> allFiles = new List<AbstractFileAnchor>();
    
    [FameProperty(Name = "allFiles")]    
    public List <AbstractFileAnchor> AllFiles
    {
      get { return allFiles; }
      set { allFiles = value; }
    }
    public void AddAllFile(AbstractFileAnchor one)
    {
      allFiles.Add(one);
    }
    
  }
}
