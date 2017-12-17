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
    [FameProperty(Name = "numberOfAccessesToForeignData")]    
    public int numberOfAccessesToForeignData { get; set; }
    
    private List<FAMIX.StructuralEntity> structuresWithDeclaredType = new List<FAMIX.StructuralEntity>();
    
    [FameProperty(Name = "structuresWithDeclaredType",  Opposite = "declaredType")]    
    public List <FAMIX.StructuralEntity> StructuresWithDeclaredType
    {
      get { return structuresWithDeclaredType; }
      set { structuresWithDeclaredType = value; }
    }
    public void AddStructuresWithDeclaredType(FAMIX.StructuralEntity one)
    {
      structuresWithDeclaredType.Add(one);
    }
    
    [FameProperty(Name = "numberOfAccessorMethods")]    
    public int numberOfAccessorMethods { get; set; }
    
    [FameProperty(Name = "numberOfProtectedMethods")]    
    public int numberOfProtectedMethods { get; set; }
    
    [FameProperty(Name = "numberOfProtectedAttributes")]    
    public int numberOfProtectedAttributes { get; set; }
    
    [FameProperty(Name = "numberOfMessageSends")]    
    public int numberOfMessageSends { get; set; }
    
    [FameProperty(Name = "numberOfComments")]    
    public int numberOfComments { get; set; }
    
    [FameProperty(Name = "numberOfPublicMethods")]    
    public int numberOfPublicMethods { get; set; }
    
    private List<FAMIX.BehaviouralEntity> behavioursWithDeclaredType = new List<FAMIX.BehaviouralEntity>();
    
    [FameProperty(Name = "behavioursWithDeclaredType",  Opposite = "declaredType")]    
    public List <FAMIX.BehaviouralEntity> BehavioursWithDeclaredType
    {
      get { return behavioursWithDeclaredType; }
      set { behavioursWithDeclaredType = value; }
    }
    public void AddBehavioursWithDeclaredType(FAMIX.BehaviouralEntity one)
    {
      behavioursWithDeclaredType.Add(one);
    }
    
    private List<FAMIX.Method> methods = new List<FAMIX.Method>();
    
    [FameProperty(Name = "methods",  Opposite = "parentType")]    
    public List <FAMIX.Method> Methods
    {
      get { return methods; }
      set { methods = value; }
    }
    public void AddMethod(FAMIX.Method one)
    {
      methods.Add(one);
    }
    
    private List<FAMIX.Attribute> attributes = new List<FAMIX.Attribute>();
    
    [FameProperty(Name = "attributes",  Opposite = "parentType")]    
    public List <FAMIX.Attribute> Attributes
    {
      get { return attributes; }
      set { attributes = value; }
    }
    public void AddAttribute(FAMIX.Attribute one)
    {
      attributes.Add(one);
    }
    
    [FameProperty(Name = "numberOfAttributesInherited")]    
    public int numberOfAttributesInherited { get; set; }
    
    [FameProperty(Name = "numberOfAnnotationInstances")]    
    public int numberOfAnnotationInstances { get; set; }
    
    [FameProperty(Name = "numberOfMethodsInherited")]    
    public int numberOfMethodsInherited { get; set; }
    
    private List<FAMIX.Inheritance> superInheritances = new List<FAMIX.Inheritance>();
    
    [FameProperty(Name = "superInheritances",  Opposite = "subclass")]    
    public List <FAMIX.Inheritance> SuperInheritances
    {
      get { return superInheritances; }
      set { superInheritances = value; }
    }
    public void AddSuperInheritance(FAMIX.Inheritance one)
    {
      superInheritances.Add(one);
    }
    
    [FameProperty(Name = "numberOfMethodProtocols")]    
    public int numberOfMethodProtocols { get; set; }
    
    [FameProperty(Name = "fanOut")]    
    public int fanOut { get; set; }
    
    [FameProperty(Name = "numberOfPublicAttributes")]    
    public int numberOfPublicAttributes { get; set; }
    
    [FameProperty(Name = "subclassHierarchyDepth")]    
    public int subclassHierarchyDepth { get; set; }
    
    [FameProperty(Name = "numberOfPrivateMethods")]    
    public int numberOfPrivateMethods { get; set; }
    
    [FameProperty(Name = "numberOfDirectSubclasses")]    
    public int numberOfDirectSubclasses { get; set; }
    
    [FameProperty(Name = "numberOfChildren")]    
    public int numberOfChildren { get; set; }
    
    [FameProperty(Name = "numberOfMethodsAdded")]    
    public int numberOfMethodsAdded { get; set; }
    
    [FameProperty(Name = "numberOfMethodsOverriden")]    
    public int numberOfMethodsOverriden { get; set; }
    
    [FameProperty(Name = "numberOfParents")]    
    public int numberOfParents { get; set; }
    
    [FameProperty(Name = "numberOfRevealedAttributes")]    
    public int numberOfRevealedAttributes { get; set; }
    
    [FameProperty(Name = "tightClassCohesion")]    
    public int tightClassCohesion { get; set; }
    
    [FameProperty(Name = "fanIn")]    
    public int fanIn { get; set; }
    
    [FameProperty(Name = "numberOfMethodsInHierarchy")]    
    public int numberOfMethodsInHierarchy { get; set; }
    
    private List<FAMIX.ParameterizedType> argumentsInParameterizedTypes = new List<FAMIX.ParameterizedType>();
    
    [FameProperty(Name = "argumentsInParameterizedTypes",  Opposite = "arguments")]    
    public List <FAMIX.ParameterizedType> ArgumentsInParameterizedTypes
    {
      get { return argumentsInParameterizedTypes; }
      set { argumentsInParameterizedTypes = value; }
    }
    public void AddArgumentsInParameterizedType(FAMIX.ParameterizedType one)
    {
      argumentsInParameterizedTypes.Add(one);
    }
    
    [FameProperty(Name = "numberOfAttributes")]    
    public int numberOfAttributes { get; set; }
    
    [FameProperty(Name = "container",  Opposite = "types")]    
    public FAMIX.ContainerEntity container { get; set; }
    
    [FameProperty(Name = "numberOfPrivateAttributes")]    
    public int numberOfPrivateAttributes { get; set; }
    
    [FameProperty(Name = "hierarchyNestingLevel")]    
    public int hierarchyNestingLevel { get; set; }
    
    private List<FAMIX.Inheritance> subInheritances = new List<FAMIX.Inheritance>();
    
    [FameProperty(Name = "subInheritances",  Opposite = "superclass")]    
    public List <FAMIX.Inheritance> SubInheritances
    {
      get { return subInheritances; }
      set { subInheritances = value; }
    }
    public void AddSubInheritance(FAMIX.Inheritance one)
    {
      subInheritances.Add(one);
    }
    
    [FameProperty(Name = "weightOfAClass")]    
    public int weightOfAClass { get; set; }
    
    private List<FAMIX.TraitUsage> outgoingTraitUsages = new List<FAMIX.TraitUsage>();
    
    [FameProperty(Name = "outgoingTraitUsages",  Opposite = "user")]    
    public List <FAMIX.TraitUsage> OutgoingTraitUsages
    {
      get { return outgoingTraitUsages; }
      set { outgoingTraitUsages = value; }
    }
    public void AddOutgoingTraitUsage(FAMIX.TraitUsage one)
    {
      outgoingTraitUsages.Add(one);
    }
    
    private List<FAMIX.Reference> incomingReferences = new List<FAMIX.Reference>();
    
    [FameProperty(Name = "incomingReferences",  Opposite = "target")]    
    public List <FAMIX.Reference> IncomingReferences
    {
      get { return incomingReferences; }
      set { incomingReferences = value; }
    }
    public void AddIncomingReference(FAMIX.Reference one)
    {
      incomingReferences.Add(one);
    }
    
    [FameProperty(Name = "numberOfStatements")]    
    public int numberOfStatements { get; set; }
    
    [FameProperty(Name = "weightedMethodCount")]    
    public int weightedMethodCount { get; set; }
    
    [FameProperty(Name = "numberOfConstructorMethods")]    
    public int numberOfConstructorMethods { get; set; }
    
    private List<Dynamix.Instance> instances = new List<Dynamix.Instance>();
    
    [FameProperty(Name = "instances",  Opposite = "type")]    
    public List <Dynamix.Instance> Instances
    {
      get { return instances; }
      set { instances = value; }
    }
    public void AddInstance(Dynamix.Instance one)
    {
      instances.Add(one);
    }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "totalNumberOfChildren")]    
    public int totalNumberOfChildren { get; set; }
    
    [FameProperty(Name = "numberOfMethods")]    
    public int numberOfMethods { get; set; }
    
    [FameProperty(Name = "numberOfAbstractMethods")]    
    public int numberOfAbstractMethods { get; set; }
    
    [FameProperty(Name = "numberOfDuplicatedLinesOfCodeInternally")]    
    public int numberOfDuplicatedLinesOfCodeInternally { get; set; }
    
  }
}
