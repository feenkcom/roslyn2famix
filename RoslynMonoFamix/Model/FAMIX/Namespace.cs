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
    private List<FAMIX.Type> clientTypes = new List<FAMIX.Type>();
    
    [FameProperty(Name = "clientTypes")]    
    public List <FAMIX.Type> ClientTypes
    {
      get { return clientTypes; }
      set { clientTypes = value; }
    }
    public void AddClientType(FAMIX.Type one)
    {
      clientTypes.Add(one);
    }
    
    private List<FAMIX.Type> providerTypes = new List<FAMIX.Type>();
    
    [FameProperty(Name = "providerTypes")]    
    public List <FAMIX.Type> ProviderTypes
    {
      get { return providerTypes; }
      set { providerTypes = value; }
    }
    public void AddProviderType(FAMIX.Type one)
    {
      providerTypes.Add(one);
    }
    
    [FameProperty(Name = "bunchCohesion")]    
    public int bunchCohesion { get; set; }
    
    [FameProperty(Name = "efferentCoupling")]    
    public int efferentCoupling { get; set; }
    
    [FameProperty(Name = "numberOfClasses")]    
    public int numberOfClasses { get; set; }
    
    [FameProperty(Name = "numberOfNonInterfacesClasses")]    
    public int numberOfNonInterfacesClasses { get; set; }
    
    [FameProperty(Name = "martinCohesion")]    
    public int martinCohesion { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "instability")]    
    public int instability { get; set; }
    
    [FameProperty(Name = "distance")]    
    public int distance { get; set; }
    
    [FameProperty(Name = "abstractness")]    
    public int abstractness { get; set; }
    
    [FameProperty(Name = "numberOfMethods")]    
    public int numberOfMethods { get; set; }
    
    [FameProperty(Name = "afferentCoupling")]    
    public int afferentCoupling { get; set; }
    
    [FameProperty(Name = "numberOfAttributes")]    
    public int numberOfAttributes { get; set; }
    
  }
}
