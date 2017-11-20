using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Inheritance")]
    public class Inheritance : Association
    {
        [FameProperty(Name = "subclass") Opposite = "superInheritances"]
        public Type subclass { get; set; }

        [FameProperty(Name = "superclass") Opposite = "subInheritances"]
        public Type superclass { get; set; }







    }
}