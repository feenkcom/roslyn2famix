using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ParameterizedType")]
  public class ParameterizedType : Type
  {
    [FameProperty(Name = "parameterizableClass",  Opposite = "parameterizedTypes")]    
    public ParameterizableClass parameterizableClass { get; set; }
    
    private List<Type> arguments = new List<Type>();
    
    [FameProperty(Name = "arguments",  Opposite = "argumentsInParameterizedTypes")]    
    public List Arguments
    {
      { return Arguments; }
      { Arguments = value; }
    }
    public void AddType(Type one)
    {
      Arguments.Add(one);
    }
    
  }
}
