using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Invocation")]
    public class Invocation : Association
    {
        [FameProperty(Name = "sender") Opposite = "outgoingInvocations"]
        public BehaviouralEntity sender { get; set; }

        [FameProperty(Name = "receiver") Opposite = "receivingInvocations"]
        public NamedEntity receiver { get; set; }

        private List<BehaviouralEntity> candidates = new List<BehaviouralEntity>();        [FameProperty(Name = "candidates") Opposite = "incomingInvocations"]        public List BehaviouralEntitys        {            get { return BehaviouralEntitys; }            set { BehaviouralEntitys = value; }        }        public void AddBehaviouralEntity(BehaviouralEntity one)        {            BehaviouralEntitys.Add(one);        }
        [FameProperty(Name = "signature")]
        public String signature { get; set; }







    }
}