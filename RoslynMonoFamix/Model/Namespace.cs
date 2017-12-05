using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Namespace")]
  public class Namespace : ScopingEntity
  {
    [FameProperty(Name = "distance")]    
    public Number distance { get; set; }
    
    [FameProperty(Name = "numberOfClasses")]    
    public Number numberOfClasses { get; set; }
    
    private List<Type> clientTypes = new List<Type>();
    
    [FameProperty(Name = "clientTypes")]    
    public List ClientTypes
    {
      { return ClientTypes; }
      { ClientTypes = value; }
    }
    public void AddType(Type one)
    {
      ClientTypes.Add(one);
    }
    
    [FameProperty(Name = "martinCohesion")]    
    public Number martinCohesion { get; set; }
    
    [FameProperty(Name = "numberOfAttributes")]    
    public Number numberOfAttributes { get; set; }
    
    private List<Type> providerTypes = new List<Type>();
    
    [FameProperty(Name = "providerTypes")]    
    public List ProviderTypes
    {
      { return ProviderTypes; }
      { ProviderTypes = value; }
    }
    public void AddType(Type one)
    {
      ProviderTypes.Add(one);
    }
    
    [FameProperty(Name = "numberOfMethods")]    
    public Number numberOfMethods { get; set; }
    
    [FameProperty(Name = "abstractness")]    
    public Number abstractness { get; set; }
    
    [FameProperty(Name = "instability")]    
    public Number instability { get; set; }
    
    [FameProperty(Name = "afferentCoupling")]    
    public Number afferentCoupling { get; set; }
    
    [FameProperty(Name = "numberOfNonInterfacesClasses")]    
    public Number numberOfNonInterfacesClasses { get; set; }
    
    [FameProperty(Name = "bunchCohesion")]    
    public Number bunchCohesion { get; set; }
    
    [FameProperty(Name = "efferentCoupling")]    
    public Number efferentCoupling { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public Number numberOfLinesOfCode { get; set; }
    
  }
}
