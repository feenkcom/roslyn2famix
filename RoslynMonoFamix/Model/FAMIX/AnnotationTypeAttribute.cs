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
    private List<FAMIX.AnnotationInstanceAttribute> annotationAttributeInstances = new List<FAMIX.AnnotationInstanceAttribute>();
    
    [FameProperty(Name = "annotationAttributeInstances",  Opposite = "annotationTypeAttribute")]    
    public List <FAMIX.AnnotationInstanceAttribute> AnnotationAttributeInstances
    {
      get { return annotationAttributeInstances; }
      set { annotationAttributeInstances = value; }
    }
    public void AddAnnotationAttributeInstance(FAMIX.AnnotationInstanceAttribute one)
    {
      annotationAttributeInstances.Add(one);
    }
    
    [FameProperty(Name = "parentAnnotationType")]    
    public FAMIX.AnnotationType parentAnnotationType { get; set; }
    
  }
}
