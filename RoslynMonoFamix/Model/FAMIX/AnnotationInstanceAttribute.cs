using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AnnotationInstanceAttribute")]
  public class AnnotationInstanceAttribute : FAMIX.SourcedEntity
  {
    [FameProperty(Name = "annotationTypeAttribute",  Opposite = "annotationAttributeInstances")]    
    public AnnotationTypeAttribute annotationTypeAttribute { get; set; }
    
    [FameProperty(Name = "value")]    
    public String value { get; set; }
    
    [FameProperty(Name = "parentAnnotationInstance",  Opposite = "attributes")]    
    public AnnotationInstance parentAnnotationInstance { get; set; }
    
  }
}
