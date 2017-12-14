using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("CFile")]
  public class CFile : FILE.File
  {
    private List<FAMIX.Include> outgoingIncludeRelations = new List<FAMIX.Include>();
    
    [FameProperty(Name = "outgoingIncludeRelations",  Opposite = "source")]    
    public List <FAMIX.Include> OutgoingIncludeRelations
    {
      get { return outgoingIncludeRelations; }
      set { outgoingIncludeRelations = value; }
    }
    public void AddOutgoingIncludeRelation(FAMIX.Include one)
    {
      outgoingIncludeRelations.Add(one);
    }
    
    private List<FAMIX.Include> incomingIncludeRelations = new List<FAMIX.Include>();
    
    [FameProperty(Name = "incomingIncludeRelations",  Opposite = "target")]    
    public List <FAMIX.Include> IncomingIncludeRelations
    {
      get { return incomingIncludeRelations; }
      set { incomingIncludeRelations = value; }
    }
    public void AddIncomingIncludeRelation(FAMIX.Include one)
    {
      incomingIncludeRelations.Add(one);
    }
    
    private List<FAMIX.CFile> includingFiles = new List<FAMIX.CFile>();
    
    [FameProperty(Name = "includingFiles")]    
    public List <FAMIX.CFile> IncludingFiles
    {
      get { return includingFiles; }
      set { includingFiles = value; }
    }
    public void AddIncludingFile(FAMIX.CFile one)
    {
      includingFiles.Add(one);
    }
    
    private List<FAMIX.CFile> includedFiles = new List<FAMIX.CFile>();
    
    [FameProperty(Name = "includedFiles")]    
    public List <FAMIX.CFile> IncludedFiles
    {
      get { return includedFiles; }
      set { includedFiles = value; }
    }
    public void AddIncludedFile(FAMIX.CFile one)
    {
      includedFiles.Add(one);
    }
    
  }
}
