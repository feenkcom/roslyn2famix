using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("DeclaredException")]
    public class DeclaredException : Exception
    {
        [FameProperty(Name = "definingMethod") Opposite = "declaredExceptions"]
        public Method definingMethod { get; set; }







    }
}