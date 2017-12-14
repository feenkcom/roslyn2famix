using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("CFile")]
  public class CFile : File
  {
    private List<Include> incomingIncludeRelations = new List<Include>();
    
    [FameProperty(Name = "incomingIncludeRelations",  Opposite = "target")]    
    public List IncomingIncludeRelations
    {
      get { return IncomingIncludeRelations; }
      set { IncomingIncludeRelations = value; }
    }
    public void AddInclude(Include one)
    {
      IncomingIncludeRelations.Add(one);
    }
    
    private List<CFile> includingFiles = new List<CFile>();
    
    [FameProperty(Name = "includingFiles")]    
    public List IncludingFiles
    {
      get { return IncludingFiles; }
      set { IncludingFiles = value; }
    }
    public void AddCFile(CFile one)
    {
      IncludingFiles.Add(one);
    }
    
    private List<CFile> includedFiles = new List<CFile>();
    
    [FameProperty(Name = "includedFiles")]    
    public List IncludedFiles
    {
      get { return IncludedFiles; }
      set { IncludedFiles = value; }
    }
    public void AddCFile(CFile one)
    {
      IncludedFiles.Add(one);
    }
    
    private List<Include> outgoingIncludeRelations = new List<Include>();
    
    [FameProperty(Name = "outgoingIncludeRelations",  Opposite = "source")]    
    public List OutgoingIncludeRelations
    {
      get { return OutgoingIncludeRelations; }
      set { OutgoingIncludeRelations = value; }
    }
    public void AddInclude(Include one)
    {
      OutgoingIncludeRelations.Add(one);
    }
    
  }
}
