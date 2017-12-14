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
    
    [FameProperty(Name = "isSetter")]    
    public Boolean isSetter { get; set; }
    
    [FameProperty(Name = "isJUnit4Test")]    
    public Boolean isJUnit4Test { get; set; }
    
    private List<FAMIX.ThrownException> thrownExceptions = new List<FAMIX.ThrownException>();
    
    [FameProperty(Name = "thrownExceptions",  Opposite = "definingMethod")]    
    public List <FAMIX.ThrownException> ThrownExceptions
    {
      get { return thrownExceptions; }
      set { thrownExceptions = value; }
    }
    public void AddThrownException(FAMIX.ThrownException one)
    {
      thrownExceptions.Add(one);
    }
    
    [FameProperty(Name = "isOverriding")]    
    public Boolean isOverriding { get; set; }
    
    [FameProperty(Name = "isClassInitializer")]    
    public Boolean isClassInitializer { get; set; }
    
    [FameProperty(Name = "parentType",  Opposite = "methods")]    
    public FAMIX.Type parentType { get; set; }
    
    [FameProperty(Name = "numberOfAnnotationInstances")]    
    public int numberOfAnnotationInstances { get; set; }
    
    private List<FAMIX.DeclaredException> declaredExceptions = new List<FAMIX.DeclaredException>();
    
    [FameProperty(Name = "declaredExceptions",  Opposite = "definingMethod")]    
    public List <FAMIX.DeclaredException> DeclaredExceptions
    {
      get { return declaredExceptions; }
      set { declaredExceptions = value; }
    }
    public void AddDeclaredException(FAMIX.DeclaredException one)
    {
      declaredExceptions.Add(one);
    }
    
    [FameProperty(Name = "isGetter")]    
    public Boolean isGetter { get; set; }
    
    private List<FAMIX.Method> invokedMethods = new List<FAMIX.Method>();
    
    [FameProperty(Name = "invokedMethods")]    
    public List <FAMIX.Method> InvokedMethods
    {
      get { return invokedMethods; }
      set { invokedMethods = value; }
    }
    public void AddInvokedMethod(FAMIX.Method one)
    {
      invokedMethods.Add(one);
    }
    
    [FameProperty(Name = "isInternalImplementation")]    
    public Boolean isInternalImplementation { get; set; }
    
    [FameProperty(Name = "isConstant")]    
    public Boolean isConstant { get; set; }
    
    private List<FAMIX.CaughtException> caughtExceptions = new List<FAMIX.CaughtException>();
    
    [FameProperty(Name = "caughtExceptions",  Opposite = "definingMethod")]    
    public List <FAMIX.CaughtException> CaughtExceptions
    {
      get { return caughtExceptions; }
      set { caughtExceptions = value; }
    }
    public void AddCaughtException(FAMIX.CaughtException one)
    {
      caughtExceptions.Add(one);
    }
    
    [FameProperty(Name = "timeStamp")]    
    public String timeStamp { get; set; }
    
    [FameProperty(Name = "kind")]    
    public String kind { get; set; }
    
    [FameProperty(Name = "numberOfInvokedMethods")]    
    public int numberOfInvokedMethods { get; set; }
    
    [FameProperty(Name = "category")]    
    public String category { get; set; }
    
    [FameProperty(Name = "isConstructor")]    
    public Boolean isConstructor { get; set; }
    
    [FameProperty(Name = "isImplementing")]    
    public Boolean isImplementing { get; set; }
    
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
    
    [FameProperty(Name = "hierarchyNestingLevel")]    
    public int hierarchyNestingLevel { get; set; }
    
    [FameProperty(Name = "isOverriden")]    
    public Boolean isOverriden { get; set; }
    
    private List<FAMIX.Method> invokingMethods = new List<FAMIX.Method>();
    
    [FameProperty(Name = "invokingMethods")]    
    public List <FAMIX.Method> InvokingMethods
    {
      get { return invokingMethods; }
      set { invokingMethods = value; }
    }
    public void AddInvokingMethod(FAMIX.Method one)
    {
      invokingMethods.Add(one);
    }
    
    [FameProperty(Name = "hasClassScope")]    
    public Boolean hasClassScope { get; set; }
    
  }
}
