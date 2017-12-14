using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Method")]
  public class Method : FAMIX.BehaviouralEntity
  {
    [FameProperty(Name = "isJUnit4Test")]    
    public Boolean isJUnit4Test { get; set; }
    
    [FameProperty(Name = "isOverriding")]    
    public Boolean isOverriding { get; set; }
    
    [FameProperty(Name = "isInternalImplementation")]    
    public Boolean isInternalImplementation { get; set; }
    
    private List<Method> invokedMethods = new List<Method>();
    
    [FameProperty(Name = "invokedMethods")]    
    public List <Method> InvokedMethods
    {
      get { return invokedMethods; }
      set { invokedMethods = value; }
    }
    public void AddInvokedMethod(Method one)
    {
      invokedMethods.Add(one);
    }
    
    [FameProperty(Name = "isConstructor")]    
    public Boolean isConstructor { get; set; }
    
    [FameProperty(Name = "timeStamp")]    
    public String timeStamp { get; set; }
    
    [FameProperty(Name = "kind")]    
    public String kind { get; set; }
    
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
    
    [FameProperty(Name = "category")]    
    public String category { get; set; }
    
    [FameProperty(Name = "isImplementing")]    
    public Boolean isImplementing { get; set; }
    
    [FameProperty(Name = "isSetter")]    
    public Boolean isSetter { get; set; }
    
    private List<DeclaredException> declaredExceptions = new List<DeclaredException>();
    
    [FameProperty(Name = "declaredExceptions",  Opposite = "definingMethod")]    
    public List <DeclaredException> DeclaredExceptions
    {
      get { return declaredExceptions; }
      set { declaredExceptions = value; }
    }
    public void AddDeclaredException(DeclaredException one)
    {
      declaredExceptions.Add(one);
    }
    
    [FameProperty(Name = "parentType",  Opposite = "methods")]    
    public Type parentType { get; set; }
    
    private List<ThrownException> thrownExceptions = new List<ThrownException>();
    
    [FameProperty(Name = "thrownExceptions",  Opposite = "definingMethod")]    
    public List <ThrownException> ThrownExceptions
    {
      get { return thrownExceptions; }
      set { thrownExceptions = value; }
    }
    public void AddThrownException(ThrownException one)
    {
      thrownExceptions.Add(one);
    }
    
    [FameProperty(Name = "isConstant")]    
    public Boolean isConstant { get; set; }
    
    [FameProperty(Name = "isClassInitializer")]    
    public Boolean isClassInitializer { get; set; }
    
    private List<Method> invokingMethods = new List<Method>();
    
    [FameProperty(Name = "invokingMethods")]    
    public List <Method> InvokingMethods
    {
      get { return invokingMethods; }
      set { invokingMethods = value; }
    }
    public void AddInvokingMethod(Method one)
    {
      invokingMethods.Add(one);
    }
    
    [FameProperty(Name = "numberOfAnnotationInstances")]    
    public int numberOfAnnotationInstances { get; set; }
    
    [FameProperty(Name = "hasClassScope")]    
    public Boolean hasClassScope { get; set; }
    
    [FameProperty(Name = "isOverriden")]    
    public Boolean isOverriden { get; set; }
    
    [FameProperty(Name = "hierarchyNestingLevel")]    
    public int hierarchyNestingLevel { get; set; }
    
    [FameProperty(Name = "isGetter")]    
    public Boolean isGetter { get; set; }
    
    [FameProperty(Name = "numberOfInvokedMethods")]    
    public int numberOfInvokedMethods { get; set; }
    
    private List<CaughtException> caughtExceptions = new List<CaughtException>();
    
    [FameProperty(Name = "caughtExceptions",  Opposite = "definingMethod")]    
    public List <CaughtException> CaughtExceptions
    {
      get { return caughtExceptions; }
      set { caughtExceptions = value; }
    }
    public void AddCaughtException(CaughtException one)
    {
      caughtExceptions.Add(one);
    }
    
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
    
  }
}
