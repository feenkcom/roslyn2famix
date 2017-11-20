using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("AnnotationInstance")]
    public class AnnotationInstance : SourcedEntity
    {
        [FameProperty(Name = "annotatedEntity") Opposite = "annotationInstances"]
        public NamedEntity annotatedEntity { get; set; }

        [FameProperty(Name = "annotationType") Opposite = "instances"]
        public AnnotationType annotationType { get; set; }

        private List<AnnotationInstanceAttribute> attributes = new List<AnnotationInstanceAttribute>();        [FameProperty(Name = "attributes", Opposite = "parentAnnotationInstance")]        public List AnnotationInstanceAttributes        {            get { return AnnotationInstanceAttributes; }            set { AnnotationInstanceAttributes = value; }        }        public void AddAnnotationInstanceAttribute(AnnotationInstanceAttribute one)        {            AnnotationInstanceAttributes.Add(one);        }






    }
}