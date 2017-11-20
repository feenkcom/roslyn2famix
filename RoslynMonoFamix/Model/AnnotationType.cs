using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("AnnotationType")]
    public class AnnotationType : Type
    {
        [FameProperty(Name = "container") Opposite = "definedAnnotationTypes"]
        public ContainerEntity container { get; set; }

        private List<AnnotationInstance> instances = new List<AnnotationInstance>();        [FameProperty(Name = "instances", Opposite = "annotationType")]        public List AnnotationInstances        {            get { return AnnotationInstances; }            set { AnnotationInstances = value; }        }        public void AddAnnotationInstance(AnnotationInstance one)        {            AnnotationInstances.Add(one);        }






    }
}