using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Class")]
  public class Class : Type
  {
    [FameProperty(Name = "lcom3")]    
    public Number lcom3 { get; set; }
    
    [FameProperty(Name = "isInterface")]    
    public Boolean isInterface { get; set; }
    
    private List<Exception> exceptions = new List<Exception>();
    
    [FameProperty(Name = "exceptions",  Opposite = "exceptionClass")]    
    public List Exceptions
    {
      { return Exceptions; }
      { Exceptions = value; }
    }
    public void AddException(Exception one)
    {
      Exceptions.Add(one);
    }
    
    [FameProperty(Name = "lcom2")]    
    public Number lcom2 { get; set; }
    
    [FameProperty(Name = "numberOfExternalDuplications")]    
    public Number numberOfExternalDuplications { get; set; }
    
    private List<Boolean> isIgnored = new List<Boolean>();
    
    [FameProperty(Name = "isIgnored")]    
    public List IsIgnored
    {
      { return IsIgnored; }
      { IsIgnored = value; }
    }
    public void AddBoolean(Boolean one)
    {
      IsIgnored.Add(one);
    }
    
    [FameProperty(Name = "numberOfInternalDuplications")]    
    public Number numberOfInternalDuplications { get; set; }
    
  }
}
