using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Package")]
  public class Package : ScopingEntity
  {
    [FameProperty(Name = "weightedMethodCount")]    
    public Number weightedMethodCount { get; set; }
    
    [FameProperty(Name = "abstractness")]    
    public Number abstractness { get; set; }
    
    [FameProperty(Name = "bunchCohesion")]    
    public Number bunchCohesion { get; set; }
    
    [FameProperty(Name = "numberOfClasses")]    
    public Number numberOfClasses { get; set; }
    
    [FameProperty(Name = "numberOfClientPackages")]    
    public Number numberOfClientPackages { get; set; }
    
    [FameProperty(Name = "numberOfMethods")]    
    public Number numberOfMethods { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public Number numberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "afferentCoupling")]    
    public Number afferentCoupling { get; set; }
    
    [FameProperty(Name = "efferentCoupling")]    
    public Number efferentCoupling { get; set; }
    
    [FameProperty(Name = "distance")]    
    public Number distance { get; set; }
    
    [FameProperty(Name = "relativeImportanceForSystem")]    
    public Number relativeImportanceForSystem { get; set; }
    
    [FameProperty(Name = "martinCohesion")]    
    public Number martinCohesion { get; set; }
    
    [FameProperty(Name = "instability")]    
    public Number instability { get; set; }
    
    private List<NamedEntity> childNamedEntities = new List<NamedEntity>();
    
    [FameProperty(Name = "childNamedEntities",  Opposite = "parentPackage")]    
    public List ChildNamedEntities
    {
      { return ChildNamedEntities; }
      { ChildNamedEntities = value; }
    }
    public void AddNamedEntity(NamedEntity one)
    {
      ChildNamedEntities.Add(one);
    }
    
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
    
  }
}
