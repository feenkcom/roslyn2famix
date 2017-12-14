using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ParameterizedType")]
  public class ParameterizedType : FAMIX.Type
  {
    [FameProperty(Name = "parameterizableClass",  Opposite = "parameterizedTypes")]    
    public ParameterizableClass parameterizableClass { get; set; }
    
    private List<Type> arguments = new List<Type>();
    
    [FameProperty(Name = "arguments",  Opposite = "argumentsInParameterizedTypes")]    
    public List <Type> Arguments
    {
      get { return arguments; }
      set { arguments = value; }
    }
    public void AddArgument(Type one)
    {
      arguments.Add(one);
    }
    
  }
}
