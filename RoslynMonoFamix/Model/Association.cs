using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Association")]
    public class Association : SourcedEntity
    {
        [FameProperty(Name = "previous") Opposite = "next"]
        public Association previous { get; set; }







    }
}