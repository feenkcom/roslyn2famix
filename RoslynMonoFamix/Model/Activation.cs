using Fame;



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








    }
}