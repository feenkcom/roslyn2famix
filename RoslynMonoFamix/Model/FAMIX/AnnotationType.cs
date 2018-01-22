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
    private List<FAMIX.AnnotationInstance> instances = new List<FAMIX.AnnotationInstance>();
    
    [FameProperty(Name = "instances",  Opposite = "annotationType")]    
    public List <FAMIX.AnnotationInstance> Instances
    {
      get { return instances; }
      set { instances = value; }
    }
    public void AddInstance(FAMIX.AnnotationInstance one)
    {
      instances.Add(one);
    }
    
    [FameProperty(Name = "container",  Opposite = "definedAnnotationTypes")]    
    public FAMIX.ContainerEntity container { get; set; }
    
  }
}
