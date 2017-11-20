using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Parameter")]
    public class Parameter : StructuralEntity
    {
        [FameProperty(Name = "parentBehaviouralEntity") Opposite = "parameters"]
        public BehaviouralEntity parentBehaviouralEntity { get; set; }







    }
}