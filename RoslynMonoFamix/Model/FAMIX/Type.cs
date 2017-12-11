using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Type")]
  public class Type : FAMIX.ContainerEntity
  {
    [FameProperty(Name = "container",  Opposite = "types")]    
    public ContainerEntity container { get; set; }
    
    private List<TraitUsage> outgoingTraitUsages = new List<TraitUsage>();
    
    [FameProperty(Name = "outgoingTraitUsages",  Opposite = "user")]    
    public List <TraitUsage> OutgoingTraitUsages
    {
      get { return outgoingTraitUsages; }
      set { outgoingTraitUsages = value; }
    }
    public void AddOutgoingTraitUsage(TraitUsage one)
    {
      outgoingTraitUsages.Add(one);
    }
    
    [FameProperty(Name = "weightedMethodCount")]    
    public int weightedMethodCount { get; set; }
    
    [FameProperty(Name = "numberOfDirectSubclasses")]    
    public int numberOfDirectSubclasses { get; set; }
    
    [FameProperty(Name = "numberOfMessageSends")]    
    public int numberOfMessageSends { get; set; }
    
    private List<BehaviouralEntity> behavioursWithDeclaredType = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "behavioursWithDeclaredType",  Opposite = "declaredType")]    
    public List <BehaviouralEntity> BehavioursWithDeclaredType
    {
      get { return behavioursWithDeclaredType; }
      set { behavioursWithDeclaredType = value; }
    }
    public void AddBehavioursWithDeclaredType(BehaviouralEntity one)
    {
      behavioursWithDeclaredType.Add(one);
    }
    
    [FameProperty(Name = "numberOfComments")]    
    public int numberOfComments { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    private List<Method> methods = new List<Method>();
    
    [FameProperty(Name = "methods",  Opposite = "parentType")]    
    public List <Method> Methods
    {
      get { return methods; }
      set { methods = value; }
    }
    public void AddMethod(Method one)
    {
      methods.Add(one);
    }
    
    [FameProperty(Name = "numberOfAccessorMethods")]    
    public int numberOfAccessorMethods { get; set; }
    
    [FameProperty(Name = "numberOfParents")]    
    public int numberOfParents { get; set; }
    
    [FameProperty(Name = "tightClassCohesion")]    
    public int tightClassCohesion { get; set; }
    
    [FameProperty(Name = "numberOfMethodsInherited")]    
    public int numberOfMethodsInherited { get; set; }
    
    [FameProperty(Name = "numberOfPrivateMethods")]    
    public int numberOfPrivateMethods { get; set; }
    
    private List<Inheritance> subInheritances = new List<Inheritance>();
    
    [FameProperty(Name = "subInheritances",  Opposite = "superclass")]    
    public List <Inheritance> SubInheritances
    {
      get { return subInheritances; }
      set { subInheritances = value; }
    }
    public void AddSubInheritance(Inheritance one)
    {
      subInheritances.Add(one);
    }
    
    [FameProperty(Name = "numberOfStatements")]    
    public int numberOfStatements { get; set; }
    
    [FameProperty(Name = "fanOut")]    
    public int fanOut { get; set; }
    
    [FameProperty(Name = "numberOfProtectedAttributes")]    
    public int numberOfProtectedAttributes { get; set; }
    
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
    
    [FameProperty(Name = "numberOfPublicAttributes")]    
    public int numberOfPublicAttributes { get; set; }
    
    [FameProperty(Name = "numberOfMethodsInHierarchy")]    
    public int numberOfMethodsInHierarchy { get; set; }
    
    [FameProperty(Name = "numberOfMethodsAdded")]    
    public int numberOfMethodsAdded { get; set; }
    
    [FameProperty(Name = "numberOfPrivateAttributes")]    
    public int numberOfPrivateAttributes { get; set; }
    
    [FameProperty(Name = "numberOfAnnotationInstances")]    
    public int numberOfAnnotationInstances { get; set; }
    
    [FameProperty(Name = "numberOfAbstractMethods")]    
    public int numberOfAbstractMethods { get; set; }
    
    [FameProperty(Name = "isTestCase")]    
    public Boolean isTestCase { get; set; }
    
    [FameProperty(Name = "weightOfAClass")]    
    public int weightOfAClass { get; set; }
    
    [FameProperty(Name = "numberOfRevealedAttributes")]    
    public int numberOfRevealedAttributes { get; set; }
    
    private List<ParameterizedType> argumentsInParameterizedTypes = new List<ParameterizedType>();
    
    [FameProperty(Name = "argumentsInParameterizedTypes",  Opposite = "arguments")]    
    public List <ParameterizedType> ArgumentsInParameterizedTypes
    {
      get { return argumentsInParameterizedTypes; }
      set { argumentsInParameterizedTypes = value; }
    }
    public void AddArgumentsInParameterizedType(ParameterizedType one)
    {
      argumentsInParameterizedTypes.Add(one);
    }
    
    private List<StructuralEntity> structuresWithDeclaredType = new List<StructuralEntity>();
    
    [FameProperty(Name = "structuresWithDeclaredType",  Opposite = "declaredType")]    
    public List <StructuralEntity> StructuresWithDeclaredType
    {
      get { return structuresWithDeclaredType; }
      set { structuresWithDeclaredType = value; }
    }
    public void AddStructuresWithDeclaredType(StructuralEntity one)
    {
      structuresWithDeclaredType.Add(one);
    }
    
    [FameProperty(Name = "fanIn")]    
    public int fanIn { get; set; }
    
    private List<TypeAlias> typeAliases = new List<TypeAlias>();
    
    [FameProperty(Name = "typeAliases",  Opposite = "aliasedType")]    
    public List <TypeAlias> TypeAliases
    {
      get { return typeAliases; }
      set { typeAliases = value; }
    }
    public void AddTypeAliase(TypeAlias one)
    {
      typeAliases.Add(one);
    }
    
    [FameProperty(Name = "numberOfDuplicatedLinesOfCodeInternally")]    
    public int numberOfDuplicatedLinesOfCodeInternally { get; set; }
    
    private List<Instance> instances = new List<Instance>();
    
    [FameProperty(Name = "instances",  Opposite = "type")]    
    public List <Instance> Instances
    {
      get { return instances; }
      set { instances = value; }
    }
    public void AddInstance(Instance one)
    {
      instances.Add(one);
    }
    
    [FameProperty(Name = "numberOfChildren")]    
    public int numberOfChildren { get; set; }
    
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
    
    [FameProperty(Name = "subclassHierarchyDepth")]    
    public int subclassHierarchyDepth { get; set; }
    
    private List<Reference> incomingReferences = new List<Reference>();
    
    [FameProperty(Name = "incomingReferences",  Opposite = "target")]    
    public List <Reference> IncomingReferences
    {
      get { return incomingReferences; }
      set { incomingReferences = value; }
    }
    public void AddIncomingReference(Reference one)
    {
      incomingReferences.Add(one);
    }
    
    [FameProperty(Name = "numberOfMethods")]    
    public int numberOfMethods { get; set; }
    
    [FameProperty(Name = "numberOfPublicMethods")]    
    public int numberOfPublicMethods { get; set; }
    
    [FameProperty(Name = "numberOfAttributesInherited")]    
    public int numberOfAttributesInherited { get; set; }
    
    [FameProperty(Name = "isAbstract")]    
    public Boolean isAbstract { get; set; }
    
    private List<Inheritance> superInheritances = new List<Inheritance>();
    
    [FameProperty(Name = "superInheritances",  Opposite = "subclass")]    
    public List <Inheritance> SuperInheritances
    {
      get { return superInheritances; }
      set { superInheritances = value; }
    }
    public void AddSuperInheritance(Inheritance one)
    {
      superInheritances.Add(one);
    }
    
    [FameProperty(Name = "numberOfMethodsOverriden")]    
    public int numberOfMethodsOverriden { get; set; }
    
    [FameProperty(Name = "numberOfMethodProtocols")]    
    public int numberOfMethodProtocols { get; set; }
    
    [FameProperty(Name = "numberOfConstructorMethods")]    
    public int numberOfConstructorMethods { get; set; }
    
    [FameProperty(Name = "isInnerClass")]    
    public Boolean isInnerClass { get; set; }
    
    private List<Attribute> attributes = new List<Attribute>();
    
    [FameProperty(Name = "attributes",  Opposite = "parentType")]    
    public List <Attribute> Attributes
    {
      get { return attributes; }
      set { attributes = value; }
    }
    public void AddAttribute(Attribute one)
    {
      attributes.Add(one);
    }
    
    [FameProperty(Name = "totalNumberOfChildren")]    
    public int totalNumberOfChildren { get; set; }
    
    [FameProperty(Name = "numberOfAttributes")]    
    public int numberOfAttributes { get; set; }
    
    [FameProperty(Name = "numberOfAccessesToForeignData")]    
    public int numberOfAccessesToForeignData { get; set; }
    
    [FameProperty(Name = "hierarchyNestingLevel")]    
    public int hierarchyNestingLevel { get; set; }
    
    [FameProperty(Name = "isJUnit4TestCase")]    
    public Boolean isJUnit4TestCase { get; set; }
    
    [FameProperty(Name = "numberOfProtectedMethods")]    
    public int numberOfProtectedMethods { get; set; }
    
  }
}
