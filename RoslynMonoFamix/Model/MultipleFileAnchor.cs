using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("MultipleFileAnchor")]
  public class MultipleFileAnchor : SourceAnchor
  {
    private List<AbstractFileAnchor> allFiles = new List<AbstractFileAnchor>();
    
    [FameProperty(Name = "allFiles")]    
    public List AllFiles
    {
      get { return AllFiles; }
      set { AllFiles = value; }
    }
    public void AddAbstractFileAnchor(AbstractFileAnchor one)
    {
      AllFiles.Add(one);
    }
    
  }
}
