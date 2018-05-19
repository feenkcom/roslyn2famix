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
    [FameProperty(Name = "annotatedEntity",  Opposite = "annotationInstances")]    
    public FAMIX.NamedEntity annotatedEntity { get; set; }
    
    [FameProperty(Name = "annotationType",  Opposite = "instances")]    
    public FAMIX.AnnotationType annotationType { get; set; }
    
    private List<FAMIX.AnnotationInstanceAttribute> attributes = new List<FAMIX.AnnotationInstanceAttribute>();
    
    [FameProperty(Name = "attributes",  Opposite = "parentAnnotationInstance")]    
    public List <FAMIX.AnnotationInstanceAttribute> Attributes
    {
      get { return attributes; }
      set { attributes = value; }
    }
    public void AddAttribute(FAMIX.AnnotationInstanceAttribute one)
    {
      attributes.Add(one);
    }
    
  }
}
