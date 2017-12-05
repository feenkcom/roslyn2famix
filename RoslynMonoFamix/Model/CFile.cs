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
      { return IncomingIncludeRelations; }
      { IncomingIncludeRelations = value; }
    }
    public void AddInclude(Include one)
    {
      IncomingIncludeRelations.Add(one);
    }
    
    private List<CFile> includingFiles = new List<CFile>();
    
    [FameProperty(Name = "includingFiles")]    
    public List IncludingFiles
    {
      { return IncludingFiles; }
      { IncludingFiles = value; }
    }
    public void AddCFile(CFile one)
    {
      IncludingFiles.Add(one);
    }
    
    private List<CFile> includedFiles = new List<CFile>();
    
    [FameProperty(Name = "includedFiles")]    
    public List IncludedFiles
    {
      { return IncludedFiles; }
      { IncludedFiles = value; }
    }
    public void AddCFile(CFile one)
    {
      IncludedFiles.Add(one);
    }
    
    private List<Include> outgoingIncludeRelations = new List<Include>();
    
    [FameProperty(Name = "outgoingIncludeRelations",  Opposite = "source")]    
    public List OutgoingIncludeRelations
    {
      { return OutgoingIncludeRelations; }
      { OutgoingIncludeRelations = value; }
    }
    public void AddInclude(Include one)
    {
      OutgoingIncludeRelations.Add(one);
    }
    
  }
}
