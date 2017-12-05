using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AnnotationInstance")]
  public class AnnotationInstance : SourcedEntity
  {
    private List<AnnotationInstanceAttribute> attributes = new List<AnnotationInstanceAttribute>();
    
    [FameProperty(Name = "attributes",  Opposite = "parentAnnotationInstance")]    
    public List Attributes
    {
      { return Attributes; }
      { Attributes = value; }
    }
    public void AddAnnotationInstanceAttribute(AnnotationInstanceAttribute one)
    {
      Attributes.Add(one);
    }
    
    [FameProperty(Name = "annotatedEntity",  Opposite = "annotationInstances")]    
    public NamedEntity annotatedEntity { get; set; }
    
    [FameProperty(Name = "annotationType",  Opposite = "instances")]    
    public AnnotationType annotationType { get; set; }
    
  }
}
