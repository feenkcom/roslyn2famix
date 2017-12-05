using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Type")]
  public class Type : ContainerEntity
  {
    [FameProperty(Name = "container",  Opposite = "types")]    
    public ContainerEntity container { get; set; }
    
    [FameProperty(Name = "numberOfMethodsInHierarchy")]    
    public Number numberOfMethodsInHierarchy { get; set; }
    
    [FameProperty(Name = "numberOfProtectedAttributes")]    
    public Number numberOfProtectedAttributes { get; set; }
    
    private List<TraitUsage> outgoingTraitUsages = new List<TraitUsage>();
    
    [FameProperty(Name = "outgoingTraitUsages",  Opposite = "user")]    
    public List OutgoingTraitUsages
    {
      get { return OutgoingTraitUsages; }
      set { OutgoingTraitUsages = value; }
    }
    public void AddTraitUsage(TraitUsage one)
    {
      OutgoingTraitUsages.Add(one);
    }
    
    private List<TypeAlias> typeAliases = new List<TypeAlias>();
    
    [FameProperty(Name = "typeAliases",  Opposite = "aliasedType")]    
    public List TypeAliases
    {
      get { return TypeAliases; }
      set { TypeAliases = value; }
    }
    public void AddTypeAlias(TypeAlias one)
    {
      TypeAliases.Add(one);
    }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public Number numberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "numberOfAnnotationInstances")]    
    public Number numberOfAnnotationInstances { get; set; }
    
    private List<ParameterizedType> argumentsInParameterizedTypes = new List<ParameterizedType>();
    
    [FameProperty(Name = "argumentsInParameterizedTypes",  Opposite = "arguments")]    
    public List ArgumentsInParameterizedTypes
    {
      get { return ArgumentsInParameterizedTypes; }
      set { ArgumentsInParameterizedTypes = value; }
    }
    public void AddParameterizedType(ParameterizedType one)
    {
      ArgumentsInParameterizedTypes.Add(one);
    }
    
    [FameProperty(Name = "numberOfPrivateMethods")]    
    public Number numberOfPrivateMethods { get; set; }
    
    private List<Type> clientTypes = new List<Type>();
    
    [FameProperty(Name = "clientTypes")]    
    public List ClientTypes
    {
      get { return ClientTypes; }
      set { ClientTypes = value; }
    }
    public void AddType(Type one)
    {
      ClientTypes.Add(one);
    }
    
    [FameProperty(Name = "numberOfPublicMethods")]    
    public Number numberOfPublicMethods { get; set; }
    
    [FameProperty(Name = "tightClassCohesion")]    
    public Number tightClassCohesion { get; set; }
    
    private List<Reference> incomingReferences = new List<Reference>();
    
    [FameProperty(Name = "incomingReferences",  Opposite = "target")]    
    public List IncomingReferences
    {
      get { return IncomingReferences; }
      set { IncomingReferences = value; }
    }
    public void AddReference(Reference one)
    {
      IncomingReferences.Add(one);
    }
    
    [FameProperty(Name = "numberOfPublicAttributes")]    
    public Number numberOfPublicAttributes { get; set; }
    
    [FameProperty(Name = "numberOfRevealedAttributes")]    
    public Number numberOfRevealedAttributes { get; set; }
    
    [FameProperty(Name = "numberOfPrivateAttributes")]    
    public Number numberOfPrivateAttributes { get; set; }
    
    [FameProperty(Name = "numberOfAttributes")]    
    public Number numberOfAttributes { get; set; }
    
    [FameProperty(Name = "numberOfComments")]    
    public Number numberOfComments { get; set; }
    
    [FameProperty(Name = "numberOfMethodProtocols")]    
    public Number numberOfMethodProtocols { get; set; }
    
    [FameProperty(Name = "numberOfAttributesInherited")]    
    public Number numberOfAttributesInherited { get; set; }
    
    private List<Instance> instances = new List<Instance>();
    
    [FameProperty(Name = "instances",  Opposite = "type")]    
    public List Instances
    {
      get { return Instances; }
      set { Instances = value; }
    }
    public void AddInstance(Instance one)
    {
      Instances.Add(one);
    }
    
    private List<Inheritance> superInheritances = new List<Inheritance>();
    
    [FameProperty(Name = "superInheritances",  Opposite = "subclass")]    
    public List SuperInheritances
    {
      get { return SuperInheritances; }
      set { SuperInheritances = value; }
    }
    public void AddInheritance(Inheritance one)
    {
      SuperInheritances.Add(one);
    }
    
    [FameProperty(Name = "numberOfChildren")]    
    public Number numberOfChildren { get; set; }
    
    [FameProperty(Name = "numberOfMethods")]    
    public Number numberOfMethods { get; set; }
    
    private List<Inheritance> subInheritances = new List<Inheritance>();
    
    [FameProperty(Name = "subInheritances",  Opposite = "superclass")]    
    public List SubInheritances
    {
      get { return SubInheritances; }
      set { SubInheritances = value; }
    }
    public void AddInheritance(Inheritance one)
    {
      SubInheritances.Add(one);
    }
    
    private List<StructuralEntity> structuresWithDeclaredType = new List<StructuralEntity>();
    
    [FameProperty(Name = "structuresWithDeclaredType",  Opposite = "declaredType")]    
    public List StructuresWithDeclaredType
    {
      get { return StructuresWithDeclaredType; }
      set { StructuresWithDeclaredType = value; }
    }
    public void AddStructuralEntity(StructuralEntity one)
    {
      StructuresWithDeclaredType.Add(one);
    }
    
    [FameProperty(Name = "isTestCase")]    
    public Boolean isTestCase { get; set; }
    
    [FameProperty(Name = "isInnerClass")]    
    public Boolean isInnerClass { get; set; }
    
    [FameProperty(Name = "hierarchyNestingLevel")]    
    public Number hierarchyNestingLevel { get; set; }
    
    [FameProperty(Name = "numberOfMethodsInherited")]    
    public Number numberOfMethodsInherited { get; set; }
    
    private List<BehaviouralEntity> behavioursWithDeclaredType = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "behavioursWithDeclaredType",  Opposite = "declaredType")]    
    public List BehavioursWithDeclaredType
    {
      get { return BehavioursWithDeclaredType; }
      set { BehavioursWithDeclaredType = value; }
    }
    public void AddBehaviouralEntity(BehaviouralEntity one)
    {
      BehavioursWithDeclaredType.Add(one);
    }
    
    private List<Method> methods = new List<Method>();
    
    [FameProperty(Name = "methods",  Opposite = "parentType")]    
    public List Methods
    {
      get { return Methods; }
      set { Methods = value; }
    }
    public void AddMethod(Method one)
    {
      Methods.Add(one);
    }
    
    [FameProperty(Name = "numberOfProtectedMethods")]    
    public Number numberOfProtectedMethods { get; set; }
    
    private List<Attribute> attributes = new List<Attribute>();
    
    [FameProperty(Name = "attributes",  Opposite = "parentType")]    
    public List Attributes
    {
      get { return Attributes; }
      set { Attributes = value; }
    }
    public void AddAttribute(Attribute one)
    {
      Attributes.Add(one);
    }
    
    [FameProperty(Name = "fanOut")]    
    public Number fanOut { get; set; }
    
    [FameProperty(Name = "weightedMethodCount")]    
    public Number weightedMethodCount { get; set; }
    
    [FameProperty(Name = "numberOfDuplicatedLinesOfCodeInternally")]    
    public Number numberOfDuplicatedLinesOfCodeInternally { get; set; }
    
    [FameProperty(Name = "numberOfAccessorMethods")]    
    public Number numberOfAccessorMethods { get; set; }
    
    [FameProperty(Name = "numberOfDirectSubclasses")]    
    public Number numberOfDirectSubclasses { get; set; }
    
    [FameProperty(Name = "weightOfAClass")]    
    public Number weightOfAClass { get; set; }
    
    [FameProperty(Name = "numberOfMethodsAdded")]    
    public Number numberOfMethodsAdded { get; set; }
    
    [FameProperty(Name = "numberOfConstructorMethods")]    
    public Number numberOfConstructorMethods { get; set; }
    
    [FameProperty(Name = "numberOfMessageSends")]    
    public Number numberOfMessageSends { get; set; }
    
    [FameProperty(Name = "totalNumberOfChildren")]    
    public Number totalNumberOfChildren { get; set; }
    
    [FameProperty(Name = "numberOfMethodsOverriden")]    
    public Number numberOfMethodsOverriden { get; set; }
    
    [FameProperty(Name = "isJUnit4TestCase")]    
    public Boolean isJUnit4TestCase { get; set; }
    
    [FameProperty(Name = "subclassHierarchyDepth")]    
    public Number subclassHierarchyDepth { get; set; }
    
    [FameProperty(Name = "numberOfStatements")]    
    public Number numberOfStatements { get; set; }
    
    private List<Type> providerTypes = new List<Type>();
    
    [FameProperty(Name = "providerTypes")]    
    public List ProviderTypes
    {
      get { return ProviderTypes; }
      set { ProviderTypes = value; }
    }
    public void AddType(Type one)
    {
      ProviderTypes.Add(one);
    }
    
    [FameProperty(Name = "numberOfParents")]    
    public Number numberOfParents { get; set; }
    
    [FameProperty(Name = "numberOfAccessesToForeignData")]    
    public Number numberOfAccessesToForeignData { get; set; }
    
    [FameProperty(Name = "numberOfAbstractMethods")]    
    public Number numberOfAbstractMethods { get; set; }
    
    [FameProperty(Name = "isAbstract")]    
    public Boolean isAbstract { get; set; }
    
    [FameProperty(Name = "fanIn")]    
    public Number fanIn { get; set; }
    
  }
}
