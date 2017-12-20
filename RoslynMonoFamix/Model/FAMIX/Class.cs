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
    [FameProperty(Name = "isInterface")]    
    public Boolean isInterface { get; set; }
    
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
    
  }
}
