using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Hismo")]
    [FameDescription("NamespaceVersion")]
    public class NamespaceVersion : EntityVersion
    {
        [FameProperty(Name = "additionOfNumberOfMethods")]
        public Number additionOfNumberOfMethods { get; set; }

        [FameProperty(Name = "evolutionOfNumberOfClasses")]
        public Number evolutionOfNumberOfClasses { get; set; }







    }
}