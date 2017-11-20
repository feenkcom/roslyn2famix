using Fame;



    [FamePackage("FAMIX")]
    [FameDescription("AnnotationInstance")]
    public class AnnotationInstance : SourcedEntity
    {
        [FameProperty(Name = "annotatedEntity") Opposite = "annotationInstances"]
        public NamedEntity annotatedEntity { get; set; }

        [FameProperty(Name = "annotationType") Opposite = "instances"]
        public AnnotationType annotationType { get; set; }








    }
}