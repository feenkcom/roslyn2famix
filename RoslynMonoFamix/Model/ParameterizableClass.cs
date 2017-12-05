using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ParameterizableClass")]
  public class ParameterizableClass : Class
  {
    private List<ParameterType> parameters = new List<ParameterType>();
    
    [FameProperty(Name = "parameters")]    
    public List Parameters
    {
      { return Parameters; }
      { Parameters = value; }
    }
    public void AddParameterType(ParameterType one)
    {
      Parameters.Add(one);
    }
    
    private List<ParameterizedType> parameterizedTypes = new List<ParameterizedType>();
    
    [FameProperty(Name = "parameterizedTypes",  Opposite = "parameterizableClass")]    
    public List ParameterizedTypes
    {
      { return ParameterizedTypes; }
      { ParameterizedTypes = value; }
    }
    public void AddParameterizedType(ParameterizedType one)
    {
      ParameterizedTypes.Add(one);
    }
    
  }
}
