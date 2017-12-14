using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("BehaviouralEntity")]
  public class BehaviouralEntity : FAMIX.ContainerEntity
  {
    private List<ImplicitVariable> implicitVariables = new List<ImplicitVariable>();
    
    [FameProperty(Name = "implicitVariables",  Opposite = "parentBehaviouralEntity")]    
    public List <ImplicitVariable> ImplicitVariables
    {
      get { return implicitVariables; }
      set { implicitVariables = value; }
    }
    public void AddImplicitVariable(ImplicitVariable one)
    {
      implicitVariables.Add(one);
    }
    
    [FameProperty(Name = "declaredType",  Opposite = "behavioursWithDeclaredType")]    
    public Type declaredType { get; set; }
    
    [FameProperty(Name = "cyclomaticComplexity")]    
    public int cyclomaticComplexity { get; set; }
    
    [FameProperty(Name = "numberOfStatements")]    
    public int numberOfStatements { get; set; }
    
    [FameProperty(Name = "numberOfParameters")]    
    public int numberOfParameters { get; set; }
    
    private List<Invocation> incomingInvocations = new List<Invocation>();
    
    [FameProperty(Name = "incomingInvocations",  Opposite = "candidates")]    
    public List <Invocation> IncomingInvocations
    {
      get { return incomingInvocations; }
      set { incomingInvocations = value; }
    }
    public void AddIncomingInvocation(Invocation one)
    {
      incomingInvocations.Add(one);
    }
    
    [FameProperty(Name = "numberOfOutgoingInvocations")]    
    public int numberOfOutgoingInvocations { get; set; }
    
    private List<BehaviouralEntity> clientBehaviours = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "clientBehaviours")]    
    public List <BehaviouralEntity> ClientBehaviours
    {
      get { return clientBehaviours; }
      set { clientBehaviours = value; }
    }
    public void AddClientBehaviour(BehaviouralEntity one)
    {
      clientBehaviours.Add(one);
    }
    
    [FameProperty(Name = "signature")]    
    public String signature { get; set; }
    
    private List<Reference> outgoingReferences = new List<Reference>();
    
    [FameProperty(Name = "outgoingReferences",  Opposite = "source")]    
    public List <Reference> OutgoingReferences
    {
      get { return outgoingReferences; }
      set { outgoingReferences = value; }
    }
    public void AddOutgoingReference(Reference one)
    {
      outgoingReferences.Add(one);
    }
    
    private List<Invocation> outgoingInvocations = new List<Invocation>();
    
    [FameProperty(Name = "outgoingInvocations",  Opposite = "sender")]    
    public List <Invocation> OutgoingInvocations
    {
      get { return outgoingInvocations; }
      set { outgoingInvocations = value; }
    }
    public void AddOutgoingInvocation(Invocation one)
    {
      outgoingInvocations.Add(one);
    }
    
    [FameProperty(Name = "numberOfConditionals")]    
    public int numberOfConditionals { get; set; }
    
    private List<Parameter> parameters = new List<Parameter>();
    
    [FameProperty(Name = "parameters",  Opposite = "parentBehaviouralEntity")]    
    public List <Parameter> Parameters
    {
      get { return parameters; }
      set { parameters = value; }
    }
    public void AddParameter(Parameter one)
    {
      parameters.Add(one);
    }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    [FameProperty(Name = "numberOfComments")]    
    public int numberOfComments { get; set; }
    
    [FameProperty(Name = "numberOfMessageSends")]    
    public int numberOfMessageSends { get; set; }
    
    [FameProperty(Name = "numberOfAccesses")]    
    public int numberOfAccesses { get; set; }
    
    private List<BehaviouralEntity> providerBehaviours = new List<BehaviouralEntity>();
    
    [FameProperty(Name = "providerBehaviours")]    
    public List <BehaviouralEntity> ProviderBehaviours
    {
      get { return providerBehaviours; }
      set { providerBehaviours = value; }
    }
    public void AddProviderBehaviour(BehaviouralEntity one)
    {
      providerBehaviours.Add(one);
    }
    
    private List<Access> accesses = new List<Access>();
    
    [FameProperty(Name = "accesses",  Opposite = "accessor")]    
    public List <Access> Accesses
    {
      get { return accesses; }
      set { accesses = value; }
    }
    public void AddAccesse(Access one)
    {
      accesses.Add(one);
    }
    
    private List<Activation> activations = new List<Activation>();
    
    [FameProperty(Name = "activations",  Opposite = "behaviour")]    
    public List <Activation> Activations
    {
      get { return activations; }
      set { activations = value; }
    }
    public void AddActivation(Activation one)
    {
      activations.Add(one);
    }
    
    private List<LocalVariable> localVariables = new List<LocalVariable>();
    
    [FameProperty(Name = "localVariables",  Opposite = "parentBehaviouralEntity")]    
    public List <LocalVariable> LocalVariables
    {
      get { return localVariables; }
      set { localVariables = value; }
    }
    public void AddLocalVariable(LocalVariable one)
    {
      localVariables.Add(one);
    }
    
  }
}
