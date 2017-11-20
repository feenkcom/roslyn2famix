using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Dynamix")]
    [FameDescription("Activation")]
    public class Activation : Event
    {
        [FameProperty(Name = "receiver") Opposite = "activationsWithReceiver"]
        public Reference receiver { get; set; }

        [FameProperty(Name = "behaviour") Opposite = "activations"]
        public BehaviouralEntity behaviour { get; set; }

        [FameProperty(Name = "return") Opposite = "activationsWithReturn"]
        public Reference return { get; set; }

        private List<Reference> arguments = new List<Reference>();        [FameProperty(Name = "arguments") Opposite = "activationsWithArgument"]        public List References        {            get { return References; }            set { References = value; }        }        public void AddReference(Reference one)        {            References.Add(one);        }






    }
}