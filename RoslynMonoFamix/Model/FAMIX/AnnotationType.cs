using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("AnnotationType")]
  public class AnnotationType : FAMIX.Type
  {
    private List<AnnotationInstance> instances = new List<AnnotationInstance>();
    
    [FameProperty(Name = "instances",  Opposite = "annotationType")]    
    public List <AnnotationInstance> Instances
    {
      get { return instances; }
      set { instances = value; }
    }
    public void AddInstance(AnnotationInstance one)
    {
      instances.Add(one);
    }
    
    [FameProperty(Name = "container",  Opposite = "definedAnnotationTypes")]    
    public ContainerEntity container { get; set; }
    
  }
}
