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
    [FameProperty(Name = "numberOfComments")]    
    public int numberOfComments { get; set; }
    
    [FameProperty(Name = "cyclomaticComplexity")]    
    public int cyclomaticComplexity { get; set; }
    
    [FameProperty(Name = "numberOfStatements")]    
    public int numberOfStatements { get; set; }
    
    [FameProperty(Name = "numberOfConditionals")]    
    public int numberOfConditionals { get; set; }
    
    private List<FAMIX.ImplicitVariable> implicitVariables = new List<FAMIX.ImplicitVariable>();
    
    [FameProperty(Name = "implicitVariables",  Opposite = "parentBehaviouralEntity")]    
    public List <FAMIX.ImplicitVariable> ImplicitVariables
    {
      get { return implicitVariables; }
      set { implicitVariables = value; }
    }
    public void AddImplicitVariable(FAMIX.ImplicitVariable one)
    {
      implicitVariables.Add(one);
    }
    
    [FameProperty(Name = "numberOfParameters")]    
    public int numberOfParameters { get; set; }
    
    private List<FAMIX.Invocation> outgoingInvocations = new List<FAMIX.Invocation>();
    
    [FameProperty(Name = "outgoingInvocations",  Opposite = "sender")]    
    public List <FAMIX.Invocation> OutgoingInvocations
    {
      get { return outgoingInvocations; }
      set { outgoingInvocations = value; }
    }
    public void AddOutgoingInvocation(FAMIX.Invocation one)
    {
      outgoingInvocations.Add(one);
    }
    
    private List<FAMIX.LocalVariable> localVariables = new List<FAMIX.LocalVariable>();
    
    [FameProperty(Name = "localVariables",  Opposite = "parentBehaviouralEntity")]    
    public List <FAMIX.LocalVariable> LocalVariables
    {
      get { return localVariables; }
      set { localVariables = value; }
    }
    public void AddLocalVariable(FAMIX.LocalVariable one)
    {
      localVariables.Add(one);
    }
    
    [FameProperty(Name = "declaredType",  Opposite = "behavioursWithDeclaredType")]    
    public FAMIX.Type declaredType { get; set; }
    
    private List<Dynamix.Activation> activations = new List<Dynamix.Activation>();
    
    [FameProperty(Name = "activations",  Opposite = "behaviour")]    
    public List <Dynamix.Activation> Activations
    {
      get { return activations; }
      set { activations = value; }
    }
    public void AddActivation(Dynamix.Activation one)
    {
      activations.Add(one);
    }
    
    private List<FAMIX.Parameter> parameters = new List<FAMIX.Parameter>();
    
    [FameProperty(Name = "parameters",  Opposite = "parentBehaviouralEntity")]    
    public List <FAMIX.Parameter> Parameters
    {
      get { return parameters; }
      set { parameters = value; }
    }
    public void AddParameter(FAMIX.Parameter one)
    {
      parameters.Add(one);
    }
    
    [FameProperty(Name = "numberOfLinesOfCode")]    
    public int numberOfLinesOfCode { get; set; }
    
    private List<FAMIX.Access> accesses = new List<FAMIX.Access>();
    
    [FameProperty(Name = "accesses",  Opposite = "accessor")]    
    public List <FAMIX.Access> Accesses
    {
      get { return accesses; }
      set { accesses = value; }
    }
    public void AddAccesse(FAMIX.Access one)
    {
      accesses.Add(one);
    }
    
    [FameProperty(Name = "signature")]    
    public String signature { get; set; }
    
    private List<FAMIX.Invocation> incomingInvocations = new List<FAMIX.Invocation>();
    
    [FameProperty(Name = "incomingInvocations",  Opposite = "candidates")]    
    public List <FAMIX.Invocation> IncomingInvocations
    {
      get { return incomingInvocations; }
      set { incomingInvocations = value; }
    }
    public void AddIncomingInvocation(FAMIX.Invocation one)
    {
      incomingInvocations.Add(one);
    }
    
    private List<FAMIX.Reference> outgoingReferences = new List<FAMIX.Reference>();
    
    [FameProperty(Name = "outgoingReferences",  Opposite = "source")]    
    public List <FAMIX.Reference> OutgoingReferences
    {
      get { return outgoingReferences; }
      set { outgoingReferences = value; }
    }
    public void AddOutgoingReference(FAMIX.Reference one)
    {
      outgoingReferences.Add(one);
    }
    
  }
}
