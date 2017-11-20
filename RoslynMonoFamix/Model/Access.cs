using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Access")]
    public class Access : Association
    {
        [FameProperty(Name = "accessor") Opposite = "accesses"]
        public BehaviouralEntity accessor { get; set; }

        [FameProperty(Name = "isWrite")]
        public Boolean isWrite { get; set; }

        [FameProperty(Name = "variable") Opposite = "incomingAccesses"]
        public StructuralEntity variable { get; set; }







    }
}