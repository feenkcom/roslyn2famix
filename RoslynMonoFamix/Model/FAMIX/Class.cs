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
    
    [FameProperty(Name = "isInterface")]    
    public Boolean isInterface { get; set; }
    
    [FameProperty(Name = "lcom3")]    
    public int lcom3 { get; set; }
    
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
    
    private List<Exception> exceptions = new List<Exception>();
    
    [FameProperty(Name = "exceptions",  Opposite = "exceptionClass")]    
    public List <Exception> Exceptions
    {
      get { return exceptions; }
      set { exceptions = value; }
    }
    public void AddException(Exception one)
    {
      exceptions.Add(one);
    }
    
    [FameProperty(Name = "numberOfExternalDuplications")]    
    public int numberOfExternalDuplications { get; set; }
    
    [FameProperty(Name = "lcom2")]    
    public int lcom2 { get; set; }
    
  }
}
