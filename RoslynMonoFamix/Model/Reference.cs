using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Reference")]
    public class Reference : Association
    {
        [FameProperty(Name = "target") Opposite = "incomingReferences"]
        public Type target { get; set; }

        [FameProperty(Name = "source") Opposite = "outgoingReferences"]
        public BehaviouralEntity source { get; set; }







    }
}{ Activations = value; }        }        public void AddActivation(Activation one)        {            Activations.Add(one);        }
        private List<Activation> activationsWithArgument = new List<Activation>();        [FameProperty(Name = "activationsWithArgument") Opposite = "arguments"]        public List Activations        {            get { return Activations; }            set { Activations = value; }        }        public void AddActivation(Activation one)        {            Activations.Add(one);        }
        private List<Activation> activationsWithReceiver = new List<Activation>();        [FameProperty(Name = "activationsWithReceiver", Opposite = "receiver")]        public List Activations        {            get { return Activations; }            set { Activations = value; }        }        public void AddActivation(Activation one)        {            Activations.Add(one);        }






    }
}