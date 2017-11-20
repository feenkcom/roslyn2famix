using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("ImplicitVariable")]
    public class ImplicitVariable : StructuralEntity
    {
        [FameProperty(Name = "parentBehaviouralEntity") Opposite = "implicitVariables"]
        public BehaviouralEntity parentBehaviouralEntity { get; set; }







    }
}