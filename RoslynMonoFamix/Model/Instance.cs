using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Dynamix")]
    [FameDescription("Instance")]
    public class Instance : Reference
    {
        [FameProperty(Name = "type") Opposite = "instances"]
        public Type type { get; set; }







    }
}