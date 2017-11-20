using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Moose")]
    [FameDescription("AbstractGroup")]
    public abstract class AbstractGroup : Entity
    {
        [FameProperty(Name = "numberOfAssociations")]
        public Number numberOfAssociations { get; set; }

        [FameProperty(Name = "numberOfLinesOfCode")]
        public Number numberOfLinesOfCode { get; set; }

        [FameProperty(Name = "numberOfPackages")]
        public Number numberOfPackages { get; set; }

        [FameProperty(Name = "numberOfEntities")]
        public Number numberOfEntities { get; set; }

        [FameProperty(Name = "numberOfItems")]
        public Number numberOfItems { get; set; }







    }
}