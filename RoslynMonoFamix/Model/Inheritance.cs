using Fame;



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