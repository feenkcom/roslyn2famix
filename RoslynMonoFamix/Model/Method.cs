using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Method")]
  public class Method : BehaviouralEntity
  {
    [FameProperty(Name = "isImplementing")]    
    public Boolean isImplementing { get; set; }
    
    private List<Method> invokedMethods = new List<Method>();
    
    [FameProperty(Name = "invokedMethods")]    
    public List InvokedMethods
    {
      get { return InvokedMethods; }
      set { InvokedMethods = value; }
    }
    public void AddMethod(Method one)
    {
      InvokedMethods.Add(one);
    }
    
    [FameProperty(Name = "isConstructor")]    
    public Boolean isConstructor { get; set; }
    
    [FameProperty(Name = "isJUnit4Test")]    
    public Boolean isJUnit4Test { get; set; }
    
    private List<Method> invokingMethods = new List<Method>();
    
    [FameProperty(Name = "invokingMethods")]    
    public List InvokingMethods
    {
      get { return InvokingMethods; }
      set { InvokingMethods = value; }
    }
    public void AddMethod(Method one)
    {
      InvokingMethods.Add(one);
    }
    
    private List<CaughtException> caughtExceptions = new List<CaughtException>();
    
    [FameProperty(Name = "caughtExceptions",  Opposite = "definingMethod")]    
    public List CaughtExceptions
    {
      get { return CaughtExceptions; }
      set { CaughtExceptions = value; }
    }
    public void AddCaughtException(CaughtException one)
    {
      CaughtExceptions.Add(one);
    }
    
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
    
    [FameProperty(Name = "isOverriden")]    
    public Boolean isOverriden { get; set; }
    
    private List<ThrownException> thrownExceptions = new List<ThrownException>();
    
    [FameProperty(Name = "thrownExceptions",  Opposite = "definingMethod")]    
    public List ThrownExceptions
    {
      get { return ThrownExceptions; }
      set { ThrownExceptions = value; }
    }
    public void AddThrownException(ThrownException one)
    {
      ThrownExceptions.Add(one);
    }
    
    [FameProperty(Name = "isOverriding")]    
    public Boolean isOverriding { get; set; }
    
    [FameProperty(Name = "numberOfInvokedMethods")]    
    public Number numberOfInvokedMethods { get; set; }
    
    [FameProperty(Name = "numberOfAnnotationInstances")]    
    public Number numberOfAnnotationInstances { get; set; }
    
    [FameProperty(Name = "isClassInitializer")]    
    public Boolean isClassInitializer { get; set; }
    
    [FameProperty(Name = "isSetter")]    
    public Boolean isSetter { get; set; }
    
    private List<DeclaredException> declaredExceptions = new List<DeclaredException>();
    
    [FameProperty(Name = "declaredExceptions",  Opposite = "definingMethod")]    
    public List DeclaredExceptions
    {
      get { return DeclaredExceptions; }
      set { DeclaredExceptions = value; }
    }
    public void AddDeclaredException(DeclaredException one)
    {
      DeclaredExceptions.Add(one);
    }
    
    [FameProperty(Name = "hierarchyNestingLevel")]    
    public Number hierarchyNestingLevel { get; set; }
    
    [FameProperty(Name = "isInternalImplementation")]    
    public Boolean isInternalImplementation { get; set; }
    
    [FameProperty(Name = "isConstant")]    
    public Boolean isConstant { get; set; }
    
    [FameProperty(Name = "hasClassScope")]    
    public Boolean hasClassScope { get; set; }
    
    [FameProperty(Name = "category")]    
    public String category { get; set; }
    
    [FameProperty(Name = "timeStamp")]    
    public String timeStamp { get; set; }
    
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
    
    [FameProperty(Name = "kind")]    
    public String kind { get; set; }
    
    [FameProperty(Name = "parentType",  Opposite = "methods")]    
    public Type parentType { get; set; }
    
    [FameProperty(Name = "isGetter")]    
    public Boolean isGetter { get; set; }
    
  }
}
