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
    private List<FAMIX.ParameterType> parameters = new List<FAMIX.ParameterType>();
    
    [FameProperty(Name = "parameters")]    
    public List <FAMIX.ParameterType> Parameters
    {
      get { return parameters; }
      set { parameters = value; }
    }
    public void AddParameter(FAMIX.ParameterType one)
    {
      parameters.Add(one);
    }
    
    private List<FAMIX.ParameterizedType> parameterizedTypes = new List<FAMIX.ParameterizedType>();
    
    [FameProperty(Name = "parameterizedTypes",  Opposite = "parameterizableClass")]    
    public List <FAMIX.ParameterizedType> ParameterizedTypes
    {
      get { return parameterizedTypes; }
      set { parameterizedTypes = value; }
    }
    public void AddParameterizedType(FAMIX.ParameterizedType one)
    {
      parameterizedTypes.Add(one);
    }
    
  }
}
