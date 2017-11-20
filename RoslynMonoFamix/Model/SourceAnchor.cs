using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("SourceAnchor")]
    public class SourceAnchor : Entity
    {
        [FameProperty(Name = "element") Opposite = "sourceAnchor"]
        public SourcedEntity element { get; set; }







    }
}