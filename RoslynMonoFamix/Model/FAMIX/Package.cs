using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Package")]
  public class Package : FAMIX.ScopingEntity
  {
    [FameProperty(Name = "relativeImportanceForSystem")]    
    public int relativeImportanceForSystem { get; set; }
    
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
    
    [FameProperty(Name = "numberOfClientPackages")]    
    public int numberOfClientPackages { get; set; }
    
    [FameProperty(Name = "numberOfClasses")]    
    public int numberOfClasses { get; set; }
    
    [FameProperty(Name = "distance")]    
    public int distance { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "bunchCohesion")]    
    public int bunchCohesion { get; set; }
    
    [FameProperty(Name = "martinCohesion")]    
    public int martinCohesion { get; set; }
    
    [FameProperty(Name = "abstractness")]    
    public int abstractness { get; set; }
    
    [FameProperty(Name = "afferentCoupling")]    
    public int afferentCoupling { get; set; }
    
    [FameProperty(Name = "instability")]    
    public int instability { get; set; }
    
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
    
    [FameProperty(Name = "numberOfMethods")]    
    public int numberOfMethods { get; set; }
    
    private List<NamedEntity> childNamedEntities = new List<NamedEntity>();
    
    [FameProperty(Name = "childNamedEntities",  Opposite = "parentPackage")]    
    public List <NamedEntity> ChildNamedEntities
    {
      get { return childNamedEntities; }
      set { childNamedEntities = value; }
    }
    public void AddChildNamedEntitie(NamedEntity one)
    {
      childNamedEntities.Add(one);
    }
    
    [FameProperty(Name = "weightedMethodCount")]    
    public int weightedMethodCount { get; set; }
    
    [FameProperty(Name = "efferentCoupling")]    
    public int efferentCoupling { get; set; }
    
  }
}
