using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Hismo")]
    [FameDescription("ClassVersion")]
    public class ClassVersion : EntityVersion
    {
        [FameProperty(Name = "additionOfNumberOfMethods")]
        public Number additionOfNumberOfMethods { get; set; }

        [FameProperty(Name = "evolutionOfNumberOfStatements")]
        public Number evolutionOfNumberOfStatements { get; set; }

        [FameProperty(Name = "evolutionOfCyclomaticComplexity")]
        public Number evolutionOfCyclomaticComplexity { get; set; }

        [FameProperty(Name = "evolutionOfNumberOfMethods")]
        public Number evolutionOfNumberOfMethods { get; set; }







    }
}