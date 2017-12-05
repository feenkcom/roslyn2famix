using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("BehaviouralEntity")]
  public class BehaviouralEntity : ContainerEntity
  {
    private List<Access> accesses = new List<Access>();
    
    [FameProperty(Name = "accesses",  Opposite = "accessor")]    
    public List Accesses
    {
      { return Accesses; }
      { Accesses = value; }
    }
    public void AddAccess(Access one)
    {
      Accesses.Add(one);
    }
    
    [FameProperty(Name = "numberOfComments")]    
    public Number numberOfComments { get; set; }
    
    [FameProperty(Name = "declaredType",  Opposite = "behavioursWithDeclaredType")]    
    public Type declaredType { get; set; }
    
    [FameProperty(Name = "signature")]    
    public String signature { get; set; }
    
    private List<LocalVariable> localVariables = new List<LocalVariable>();
    
    [FameProperty(Name = "localVariables",  Opposite = "parentBehaviouralEntity")]    
    public List LocalVariables
    {
      { return LocalVariables; }
      { LocalVariables = value; }
    }
    public void AddLocalVariable(LocalVariable one)
    {
      LocalVariables.Add(one);
    }
    
    [FameProperty(Name = "numberOfOutgoingInvocations")]    
    public Number numberOfOutgoingInvocations { get; set; }
    
    private List<Invocation> outgoingInvocations = new List<Invocation>();
    
    [FameProperty(Name = "outgoingInvocations",  Opposite = "sender")]    
    public List OutgoingInvocations
    {
      { return OutgoingInvocations; }
      { OutgoingInvocations = value; }
    }
    public void AddInvocation(Invocation one)
    {
      OutgoingInvocations.Add(one);
    }
    
    private List<Activation> activations = new List<Activation>();
    
    [FameProperty(Name = "activations",  Opposite = "behaviour")]    
    public List Activations
    {
      { return Activations; }
      { Activations = value; }
    }
    public void AddActivation(Activation one)
    {
      Activations.Add(one);
    }
    
    private List<Parameter> parameters = new List<Parameter>();
    
    [FameProperty(Name = "parameters",  Opposite = "parentBehaviouralEntity")]    
    public List Parameters
    {
      { return Parameters; }
      { Parameters = value; }
    }
    public void AddParameter(Parameter one)
    {
      Parameters.Add(one);
    }
    
    private List<Invocation> incomingInvocations = new List<Invocation>();
    
    [FameProperty(Name = "incomingInvocations",  Opposite = "candidates")]    
    public List IncomingInvocations
    {
      { return IncomingInvocations; }
      { IncomingInvocations = value; }
    }
    public void AddInvocation(Invocation one)
    {
      IncomingInvocations.Add(one);
    }
    
    [FameProperty(Name = "numberOfConditionals")]    
    public Number numberOfConditionals { get; set; }
    
    [FameProperty(Name = "cyclomaticComplexity")]    
    public Number cyclomaticComplexity { get; set; }
    
    private List<BehaviouralEntity> providerBehaviours = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "providerBehaviours")]    
    public List ProviderBehaviours
    {
      { return ProviderBehaviours; }
      { ProviderBehaviours = value; }
    }
    public void AddBehaviouralEntity(BehaviouralEntity one)
    {
      ProviderBehaviours.Add(one);
    }
    
    [FameProperty(Name = "numberOfStatements")]    
    public Number numberOfStatements { get; set; }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public Number numberOfLinesOfCode { get; set; }
    
    private List<Reference> outgoingReferences = new List<Reference>();
    
    [FameProperty(Name = "outgoingReferences",  Opposite = "source")]    
    public List OutgoingReferences
    {
      { return OutgoingReferences; }
      { OutgoingReferences = value; }
    }
    public void AddReference(Reference one)
    {
      OutgoingReferences.Add(one);
    }
    
    private List<BehaviouralEntity> clientBehaviours = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "clientBehaviours")]    
    public List ClientBehaviours
    {
      { return ClientBehaviours; }
      { ClientBehaviours = value; }
    }
    public void AddBehaviouralEntity(BehaviouralEntity one)
    {
      ClientBehaviours.Add(one);
    }
    
    [FameProperty(Name = "numberOfMessageSends")]    
    public Number numberOfMessageSends { get; set; }
    
    private List<ImplicitVariable> implicitVariables = new List<ImplicitVariable>();
    
    [FameProperty(Name = "implicitVariables",  Opposite = "parentBehaviouralEntity")]    
    public List ImplicitVariables
    {
      { return ImplicitVariables; }
      { ImplicitVariables = value; }
    }
    public void AddImplicitVariable(ImplicitVariable one)
    {
      ImplicitVariables.Add(one);
    }
    
    [FameProperty(Name = "numberOfParameters")]    
    public Number numberOfParameters { get; set; }
    
    [FameProperty(Name = "numberOfAccesses")]    
    public Number numberOfAccesses { get; set; }
    
  }
}
