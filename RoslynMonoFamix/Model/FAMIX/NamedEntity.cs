using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("NamedEntity")]
  public class NamedEntity : FAMIX.SourcedEntity
  {
    [FameProperty(Name = "parentPackage",  Opposite = "childNamedEntities")]    
    public FAMIX.Package parentPackage { get; set; }
    
    [FameProperty(Name = "isProtected")]    
    public Boolean isProtected { get; set; }
    
    [FameProperty(Name = "isPublic")]    
    public Boolean isPublic { get; set; }
    
    private List<String> modifiers = new List<String>();
    
    [FameProperty(Name = "modifiers")]    
    public List <String> Modifiers
    {
      get { return modifiers; }
      set { modifiers = value; }
    }
    public void AddModifier(String one)
    {
      modifiers.Add(one);
    }
    
    [FameProperty(Name = "nameLength")]    
    public int nameLength { get; set; }
    
    private List<FAMIX.Invocation> receivingInvocations = new List<FAMIX.Invocation>();
    
    [FameProperty(Name = "receivingInvocations",  Opposite = "receiver")]    
    public List <FAMIX.Invocation> ReceivingInvocations
    {
      get { return receivingInvocations; }
      set { receivingInvocations = value; }
    }
    public void AddReceivingInvocation(FAMIX.Invocation one)
    {
      receivingInvocations.Add(one);
    }
    
    [FameProperty(Name = "isAbstract")]    
    public Boolean isAbstract { get; set; }
    
    private List<FAMIX.AnnotationInstance> annotationInstances = new List<FAMIX.AnnotationInstance>();
    
    [FameProperty(Name = "annotationInstances",  Opposite = "annotatedEntity")]    
    public List <FAMIX.AnnotationInstance> AnnotationInstances
    {
      get { return annotationInstances; }
      set { annotationInstances = value; }
    }
    public void AddAnnotationInstance(FAMIX.AnnotationInstance one)
    {
      annotationInstances.Add(one);
    }
    
    [FameProperty(Name = "isFinal")]    
    public Boolean isFinal { get; set; }
    
    [FameProperty(Name = "isPrivate")]    
    public Boolean isPrivate { get; set; }
    
    [FameProperty(Name = "isStub")]    
    public Boolean isStub { get; set; }
    
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
    [FameProperty(Name = "isPackage")]    
    public Boolean isPackage { get; set; }
    
  }
}
