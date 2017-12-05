using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AnnotationInstanceAttribute")]
  public class AnnotationInstanceAttribute : SourcedEntity
  {
    [FameProperty(Name = "parentAnnotationInstance",  Opposite = "attributes")]    
    public AnnotationInstance parentAnnotationInstance { get; set; }
    
    [FameProperty(Name = "annotationTypeAttribute",  Opposite = "annotationAttributeInstances")]    
    public AnnotationTypeAttribute annotationTypeAttribute { get; set; }
    
    [FameProperty(Name = "value")]    
    public String value { get; set; }
    
  }
}
