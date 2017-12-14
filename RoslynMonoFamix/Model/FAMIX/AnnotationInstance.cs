using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AnnotationInstance")]
  public class AnnotationInstance : FAMIX.SourcedEntity
  {
    private List<AnnotationInstanceAttribute> attributes = new List<AnnotationInstanceAttribute>();
    
    [FameProperty(Name = "attributes",  Opposite = "parentAnnotationInstance")]    
    public List <AnnotationInstanceAttribute> Attributes
    {
      get { return attributes; }
      set { attributes = value; }
    }
    public void AddAttribute(AnnotationInstanceAttribute one)
    {
      attributes.Add(one);
    }
    
    [FameProperty(Name = "annotationType",  Opposite = "instances")]    
    public AnnotationType annotationType { get; set; }
    
    [FameProperty(Name = "annotatedEntity",  Opposite = "annotationInstances")]    
    public NamedEntity annotatedEntity { get; set; }
    
  }
}
