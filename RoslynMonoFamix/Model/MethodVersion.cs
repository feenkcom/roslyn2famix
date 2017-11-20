using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Hismo")]
    [FameDescription("MethodVersion")]
    public class MethodVersion : EntityVersion
    {
        [FameProperty(Name = "evolutionOfCyclomaticComplexity")]
        public Number evolutionOfCyclomaticComplexity { get; set; }

        [FameProperty(Name = "evolutionOfNumberOfStatements")]
        public Number evolutionOfNumberOfStatements { get; set; }

        [FameProperty(Name = "additionOfCyclomaticComplexity")]
        public Number additionOfCyclomaticComplexity { get; set; }







    }
}