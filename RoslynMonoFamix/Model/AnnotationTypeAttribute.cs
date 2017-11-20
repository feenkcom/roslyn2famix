using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("AnnotationTypeAttribute")]
    public class AnnotationTypeAttribute : Attribute
    {
        private List<AnnotationInstanceAttribute> annotationAttributeInstances = new List<AnnotationInstanceAttribute>();        [FameProperty(Name = "annotationAttributeInstances", Opposite = "annotationTypeAttribute")]        public List AnnotationInstanceAttributes        {            get { return AnnotationInstanceAttributes; }            set { AnnotationInstanceAttributes = value; }        }        public void AddAnnotationInstanceAttribute(AnnotationInstanceAttribute one)        {            AnnotationInstanceAttributes.Add(one);        }






    }
}