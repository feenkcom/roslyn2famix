using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("AnnotationInstanceAttribute")]
    public class AnnotationInstanceAttribute : SourcedEntity
    {
        [FameProperty(Name = "annotationTypeAttribute") Opposite = "annotationAttributeInstances"]
        public AnnotationTypeAttribute annotationTypeAttribute { get; set; }

        [FameProperty(Name = "value")]
        public String value { get; set; }

        [FameProperty(Name = "parentAnnotationInstance") Opposite = "attributes"]
        public AnnotationInstance parentAnnotationInstance { get; set; }







    }
}