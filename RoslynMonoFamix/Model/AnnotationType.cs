using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AnnotationType")]
  public class AnnotationType : Type
  {
    [FameProperty(Name = "container",  Opposite = "definedAnnotationTypes")]    
    public ContainerEntity container { get; set; }
    
    private List<AnnotationInstance> instances = new List<AnnotationInstance>();
    
    [FameProperty(Name = "instances",  Opposite = "annotationType")]    
    public List Instances
    {
      { return Instances; }
      { Instances = value; }
    }
    public void AddAnnotationInstance(AnnotationInstance one)
    {
      Instances.Add(one);
    }
    
  }
}
