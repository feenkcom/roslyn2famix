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
    [FameProperty(Name = "isPublic")]    
    public Boolean isPublic { get; set; }
    
    [FameProperty(Name = "isPrivate")]    
    public Boolean isPrivate { get; set; }
    
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
    
    [FameProperty(Name = "isAbstract")]    
    public Boolean isAbstract { get; set; }
    
    [FameProperty(Name = "isPackage")]    
    public Boolean isPackage { get; set; }
    
    [FameProperty(Name = "isStub")]    
    public Boolean isStub { get; set; }
    
    [FameProperty(Name = "isFinal")]    
    public Boolean isFinal { get; set; }
    
    [FameProperty(Name = "isProtected")]    
    public Boolean isProtected { get; set; }
    
    [FameProperty(Name = "parentPackage",  Opposite = "childNamedEntities")]    
    public Package parentPackage { get; set; }
    
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
    private List<AnnotationInstance> annotationInstances = new List<AnnotationInstance>();
    
    [FameProperty(Name = "annotationInstances",  Opposite = "annotatedEntity")]    
    public List <AnnotationInstance> AnnotationInstances
    {
      get { return annotationInstances; }
      set { annotationInstances = value; }
    }
    public void AddAnnotationInstance(AnnotationInstance one)
    {
      annotationInstances.Add(one);
    }
    
    [FameProperty(Name = "nameLength")]    
    public int nameLength { get; set; }
    
    private List<Invocation> receivingInvocations = new List<Invocation>();
    
    [FameProperty(Name = "receivingInvocations",  Opposite = "receiver")]    
    public List <Invocation> ReceivingInvocations
    {
      get { return receivingInvocations; }
      set { receivingInvocations = value; }
    }
    public void AddReceivingInvocation(Invocation one)
    {
      receivingInvocations.Add(one);
    }
    
  }
}
