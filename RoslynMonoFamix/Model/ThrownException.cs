using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("ThrownException")]
    public class ThrownException : Exception
    {
        [FameProperty(Name = "definingMethod") Opposite = "thrownExceptions"]
        public Method definingMethod { get; set; }







    }
}