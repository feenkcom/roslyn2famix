using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Class")]
  public class Class : FAMIX.Type
  {
    [FameProperty(Name = "numberOfInternalDuplications")]    
    public int numberOfInternalDuplications { get; set; }
    
    private List<Boolean> isIgnored = new List<Boolean>();
    
    [FameProperty(Name = "isIgnored")]    
    public List <Boolean> IsIgnored
    {
      get { return isIgnored; }
      set { isIgnored = value; }
    }
    public void AddIsIgnored(Boolean one)
    {
      isIgnored.Add(one);
    }
    
    [FameProperty(Name = "lcom2")]    
    public int lcom2 { get; set; }
    
    private List<FAMIX.Exception> exceptions = new List<FAMIX.Exception>();
    
    [FameProperty(Name = "exceptions",  Opposite = "exceptionClass")]    
    public List <FAMIX.Exception> Exceptions
    {
      get { return exceptions; }
      set { exceptions = value; }
    }
    public void AddException(FAMIX.Exception one)
    {
      exceptions.Add(one);
    }
    
    [FameProperty(Name = "isInterface")]    
    public Boolean isInterface { get; set; }
    
    [FameProperty(Name = "numberOfExternalDuplications")]    
    public int numberOfExternalDuplications { get; set; }
    
    [FameProperty(Name = "lcom3")]    
    public int lcom3 { get; set; }
    
  }
}
