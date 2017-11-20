using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Moose")]
    [FameDescription("Model")]
    public class Model : AbstractGroup
    {
        [FameProperty(Name = "numberOfLinesOfCodePerClass")]
        public Number numberOfLinesOfCodePerClass { get; set; }

        [FameProperty(Name = "numberOfMethods")]
        public Number numberOfMethods { get; set; }

        [FameProperty(Name = "sourceLanguage")]
        public SourceLanguage sourceLanguage { get; set; }

        [FameProperty(Name = "numberOfLinesOfCodePerMethod")]
        public Number numberOfLinesOfCodePerMethod { get; set; }

        [FameProperty(Name = "numberOfClasses")]
        public Number numberOfClasses { get; set; }

        [FameProperty(Name = "numberOfLinesOfCodePerPackage")]
        public Number numberOfLinesOfCodePerPackage { get; set; }

        [FameProperty(Name = "numberOfClassesPerPackage")]
        public Number numberOfClassesPerPackage { get; set; }

        [FameProperty(Name = "numberOfClassesPerPackage")]
        public Number numberOfClassesPerPackage { get; set; }

        [FameProperty(Name = "numberOfModelClasses")]
        public Number numberOfModelClasses { get; set; }

        [FameProperty(Name = "numberOfModelMethods")]
        public Number numberOfModelMethods { get; set; }







    }
}