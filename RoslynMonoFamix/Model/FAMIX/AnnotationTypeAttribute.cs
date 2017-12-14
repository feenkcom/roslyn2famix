using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AnnotationTypeAttribute")]
  public class AnnotationTypeAttribute : FAMIX.Attribute
  {
    [FameProperty(Name = "parentAnnotationType")]    
    public AnnotationType parentAnnotationType { get; set; }
    
    private List<AnnotationInstanceAttribute> annotationAttributeInstances = new List<AnnotationInstanceAttribute>();
    
    [FameProperty(Name = "annotationAttributeInstances",  Opposite = "annotationTypeAttribute")]    
    public List <AnnotationInstanceAttribute> AnnotationAttributeInstances
    {
      get { return annotationAttributeInstances; }
      set { annotationAttributeInstances = value; }
    }
    public void AddAnnotationAttributeInstance(AnnotationInstanceAttribute one)
    {
      annotationAttributeInstances.Add(one);
    }
    
  }
}
