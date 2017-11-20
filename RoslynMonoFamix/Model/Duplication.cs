using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Dude")]
    [FameDescription("Duplication")]
    public class Duplication : Entity
    {
        [FameProperty(Name = "multiplicationInvolved") Opposite = "duplications"]
        public Multiplication multiplicationInvolved { get; set; }







    }
}