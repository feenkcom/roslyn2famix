using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("AnnotationType")]
    public class AnnotationType : FAMIX.Type
    {
        [FameProperty(Name = "container", Opposite = "definedAnnotationTypes")]
        public new FAMIX.ContainerEntity container { get; set; }

        private List<FAMIX.AnnotationInstance> instances = new List<FAMIX.AnnotationInstance>();

        [FameProperty(Name = "instances", Opposite = "annotationType")]
        public new List<FAMIX.AnnotationInstance> Instances
        {
            get { return instances; }
            set { instances = value; }
        }
        public void AddInstance(FAMIX.AnnotationInstance one)
        {
            instances.Add(one);
        }

    }
}
