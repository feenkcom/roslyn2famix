using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("LocalVariable")]
    public class LocalVariable : StructuralEntity
    {
        [FameProperty(Name = "parentBehaviouralEntity") Opposite = "localVariables"]
        public BehaviouralEntity parentBehaviouralEntity { get; set; }







    }
}