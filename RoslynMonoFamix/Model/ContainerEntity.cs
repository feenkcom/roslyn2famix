using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("ContainerEntity")]
    public class ContainerEntity : NamedEntity
    {
        private List<Type> types = new List<Type>();        [FameProperty(Name = "types", Opposite = "container")]        public List	 Types        {            get { return Types; }            set { Types = value; }        }        public void AddType(Type one)        {            Types.Add(one);        }
        private List<Function> functions = new List<Function>();        [FameProperty(Name = "functions", Opposite = "container")]        public List Functions        {            get { return Functions; }            set { Functions = value; }        }        public void AddFunction(Function one)        {            Functions.Add(one);        }
        private List<AnnotationType> definedAnnotationTypes = new List<AnnotationType>();        [FameProperty(Name = "definedAnnotationTypes", Opposite = "container")]        public List AnnotationTypes        {            get { return AnnotationTypes; }            set { AnnotationTypes = value; }        }        public void AddAnnotationType(AnnotationType one)        {            AnnotationTypes.Add(one);        }






    }
}