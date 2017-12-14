using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ParameterizableClass")]
  public class ParameterizableClass : FAMIX.Class
  {
    private List<ParameterType> parameters = new List<ParameterType>();
    
    [FameProperty(Name = "parameters")]    
    public List <ParameterType> Parameters
    {
      get { return parameters; }
      set { parameters = value; }
    }
    public void AddParameter(ParameterType one)
    {
      parameters.Add(one);
    }
    
    private List<ParameterizedType> parameterizedTypes = new List<ParameterizedType>();
    
    [FameProperty(Name = "parameterizedTypes",  Opposite = "parameterizableClass")]    
    public List <ParameterizedType> ParameterizedTypes
    {
      get { return parameterizedTypes; }
      set { parameterizedTypes = value; }
    }
    public void AddParameterizedType(ParameterizedType one)
    {
      parameterizedTypes.Add(one);
    }
    
  }
}
