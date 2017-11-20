using Fame;
using System.Collections.Generic;

namespace Model
{



    [FamePackage("FAMIX")]
    [FameDescription("Attribute")]
    public class Attribute : StructuralEntity
    {
        [FameProperty(Name = "parentType") Opposite = "attributes"]
        public Type parentType { get; set; }

        [FameProperty(Name = "hasClassScope")]
        public Boolean hasClassScope { get; set; }







    }
}