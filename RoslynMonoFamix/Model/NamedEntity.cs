using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("NamedEntity")]
    public class NamedEntity : SourcedEntity
    {
        [FameProperty(Name = "isStub")]
        public Boolean isStub { get; set; }

	     private List<String> modifiers = new List<String>();        [FameProperty(Name = "modifiers")]        public Listmodifiers Strings        {            get { return Strings; }            set { Strings = value; }        }        public void AddString(String one)        {            Strings.Add(one);        }
        private List<AnnotationInstance> annotationInstances = new List<AnnotationInstance>();        [FameProperty(Name = "annotationInstances", Opposite = "annotatedEntity")]        public List AnnotationInstances        {            get { return AnnotationInstances; }            set { AnnotationInstances = value; }        }        public void AddAnnotationInstance(AnnotationInstance one)        {            AnnotationInstances.Add(one);        }
        private List<Invocation> receivingInvocations = new List<Invocation>();        [FameProperty(Name = "receivingInvocations", Opposite = "receiver")]        public List Invocations        {            get { return Invocations; }            set { Invocations = value; }        }        public void AddInvocation(Invocation one)        {            Invocations.Add(one);        }
        [FameProperty(Name = "name")]
        public String name { get; set; }

        [FameProperty(Name = "parentPackage") Opposite = "childNamedEntities"]
        public Package parentPackage { get; set; }







    }
}