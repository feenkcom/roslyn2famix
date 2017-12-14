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
    private List<Include> outgoingIncludeRelations = new List<Include>();
    
    [FameProperty(Name = "outgoingIncludeRelations",  Opposite = "source")]    
    public List <Include> OutgoingIncludeRelations
    {
      get { return outgoingIncludeRelations; }
      set { outgoingIncludeRelations = value; }
    }
    public void AddOutgoingIncludeRelation(Include one)
    {
      outgoingIncludeRelations.Add(one);
    }
    
    private List<CFile> includingFiles = new List<CFile>();
    
    [FameProperty(Name = "includingFiles")]    
    public List <CFile> IncludingFiles
    {
      get { return includingFiles; }
      set { includingFiles = value; }
    }
    public void AddIncludingFile(CFile one)
    {
      includingFiles.Add(one);
    }
    
    private List<CFile> includedFiles = new List<CFile>();
    
    [FameProperty(Name = "includedFiles")]    
    public List <CFile> IncludedFiles
    {
      get { return includedFiles; }
      set { includedFiles = value; }
    }
    public void AddIncludedFile(CFile one)
    {
      includedFiles.Add(one);
    }
    
    private List<Include> incomingIncludeRelations = new List<Include>();
    
    [FameProperty(Name = "incomingIncludeRelations",  Opposite = "target")]    
    public List <Include> IncomingIncludeRelations
    {
      get { return incomingIncludeRelations; }
      set { incomingIncludeRelations = value; }
    }
    public void AddIncomingIncludeRelation(Include one)
    {
      incomingIncludeRelations.Add(one);
    }
    
  }
}
