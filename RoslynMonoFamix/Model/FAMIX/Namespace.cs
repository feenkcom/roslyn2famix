using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Namespace")]
  public class Namespace : FAMIX.ScopingEntity
  {
    [FameProperty(Name = "numberOfAttributes")]    
    public int numberOfAttributes { get; set; }
    
    [FameProperty(Name = "instability")]    
    public int instability { get; set; }
    
    [FameProperty(Name = "numberOfMethods")]    
    public int numberOfMethods { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "abstractness")]    
    public int abstractness { get; set; }
    
    [FameProperty(Name = "martinCohesion")]    
    public int martinCohesion { get; set; }
    
    [FameProperty(Name = "efferentCoupling")]    
    public int efferentCoupling { get; set; }
    
    [FameProperty(Name = "numberOfClasses")]    
    public int numberOfClasses { get; set; }
    
    [FameProperty(Name = "distance")]    
    public int distance { get; set; }
    
    private List<Type> clientTypes = new List<Type>();
    
    [FameProperty(Name = "clientTypes")]    
    public List <Type> ClientTypes
    {
      get { return clientTypes; }
      set { clientTypes = value; }
    }
    public void AddClientType(Type one)
    {
      clientTypes.Add(one);
    }
    
    [FameProperty(Name = "afferentCoupling")]    
    public int afferentCoupling { get; set; }
    
    private List<Type> providerTypes = new List<Type>();
    
    [FameProperty(Name = "providerTypes")]    
    public List <Type> ProviderTypes
    {
      get { return providerTypes; }
      set { providerTypes = value; }
    }
    public void AddProviderType(Type one)
    {
      providerTypes.Add(one);
    }
    
    [FameProperty(Name = "bunchCohesion")]    
    public int bunchCohesion { get; set; }
    
    [FameProperty(Name = "numberOfNonInterfacesClasses")]    
    public int numberOfNonInterfacesClasses { get; set; }
    
  }
}
