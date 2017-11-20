using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Exception")]
    public class Exception : Entity
    {
        [FameProperty(Name = "exceptionClass") Opposite = "exceptions"]
        public Class exceptionClass { get; set; }







    }
}