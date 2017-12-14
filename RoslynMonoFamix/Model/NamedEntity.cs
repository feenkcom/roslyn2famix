using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("NamedEntity")]
  public class NamedEntity : SourcedEntity
  {
    [FameProperty(Name = "isAbstract")]    
    public Boolean isAbstract { get; set; }
    
    private List<Invocation> receivingInvocations = new List<Invocation>();
    
    [FameProperty(Name = "receivingInvocations",  Opposite = "receiver")]    
    public List ReceivingInvocations
    {
      get { return ReceivingInvocations; }
      set { ReceivingInvocations = value; }
    }
    public void AddInvocation(Invocation one)
    {
      ReceivingInvocations.Add(one);
    }
    
    private List<AnnotationInstance> annotationInstances = new List<AnnotationInstance>();
    
    [FameProperty(Name = "annotationInstances",  Opposite = "annotatedEntity")]    
    public List AnnotationInstances
    {
      get { return AnnotationInstances; }
      set { AnnotationInstances = value; }
    }
    public void AddAnnotationInstance(AnnotationInstance one)
    {
      AnnotationInstances.Add(one);
    }
    
    [FameProperty(Name = "isPrivate")]    
    public Boolean isPrivate { get; set; }
    
    [FameProperty(Name = "name")]    
    public String name { get; set; }
    
    [FameProperty(Name = "isFinal")]    
    public Boolean isFinal { get; set; }
    
    [FameProperty(Name = "isPublic")]    
    public Boolean isPublic { get; set; }
    
    [FameProperty(Name = "isProtected")]    
    public Boolean isProtected { get; set; }
    
    private List<String> modifiers = new List<String>();
    
    [FameProperty(Name = "modifiers")]    
    public List Modifiers
    {
      get { return Modifiers; }
      set { Modifiers = value; }
    }
    public void AddString(String one)
    {
      Modifiers.Add(one);
    }
    
    [FameProperty(Name = "isPackage")]    
    public Boolean isPackage { get; set; }
    
    [FameProperty(Name = "parentPackage",  Opposite = "childNamedEntities")]    
    public Package parentPackage { get; set; }
    
    [FameProperty(Name = "nameLength")]    
    public Number nameLength { get; set; }
    
    [FameProperty(Name = "isStub")]    
    public Boolean isStub { get; set; }
    
  }
}
