using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AnnotationTypeAttribute")]
  public class AnnotationTypeAttribute : Attribute
  {
    private List<AnnotationInstanceAttribute> annotationAttributeInstances = new List<AnnotationInstanceAttribute>();
    
    [FameProperty(Name = "annotationAttributeInstances",  Opposite = "annotationTypeAttribute")]    
    public List AnnotationAttributeInstances
    {
      get { return AnnotationAttributeInstances; }
      set { AnnotationAttributeInstances = value; }
    }
    public void AddAnnotationInstanceAttribute(AnnotationInstanceAttribute one)
    {
      AnnotationAttributeInstances.Add(one);
    }
    
    [FameProperty(Name = "parentAnnotationType")]    
    public AnnotationType parentAnnotationType { get; set; }
    
  }
}
