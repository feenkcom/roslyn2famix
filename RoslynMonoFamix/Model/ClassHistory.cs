using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Hismo")]
    [FameDescription("ClassHistory")]
    public class ClassHistory : AbstractHistory
    {
        [FameProperty(Name = "allEvolutionOfNumberOfMethods")]
        public Number allEvolutionOfNumberOfMethods { get; set; }

        [FameProperty(Name = "latestEvolutionOfNumberOfMethods")]
        public Number latestEvolutionOfNumberOfMethods { get; set; }

        [FameProperty(Name = "latestEvolutionOfNumberOfStatements")]
        public Number latestEvolutionOfNumberOfStatements { get; set; }

        [FameProperty(Name = "allEarliestEvolutionOfNumberOfMethods")]
        public Number allEarliestEvolutionOfNumberOfMethods { get; set; }

        [FameProperty(Name = "earliestEvolutionOfNumberOfMethods")]
        public Number earliestEvolutionOfNumberOfMethods { get; set; }

        [FameProperty(Name = "earliestEvolutionOfNumberOfAttributes")]
        public Number earliestEvolutionOfNumberOfAttributes { get; set; }

        [FameProperty(Name = "evolutionOfNumberOfStatementsPer5")]
        public Number evolutionOfNumberOfStatementsPer5 { get; set; }

        [FameProperty(Name = "earliestEvolutionOfNumberOfMethods")]
        public Number earliestEvolutionOfNumberOfMethods { get; set; }

        [FameProperty(Name = "allLatestEvolutionOfNumberOfMethods")]
        public Number allLatestEvolutionOfNumberOfMethods { get; set; }

        [FameProperty(Name = "stabilityOfNumberOfMethods")]
        public Number stabilityOfNumberOfMethods { get; set; }

        [FameProperty(Name = "latestEvolutionOfNumberOfLinesOfCode")]
        public Number latestEvolutionOfNumberOfLinesOfCode { get; set; }

        [FameProperty(Name = "evolutionOfNumberOfLinesOfCode")]
        public Number evolutionOfNumberOfLinesOfCode { get; set; }

        [FameProperty(Name = "stabilityOfNumberOfAttributes")]
        public Number stabilityOfNumberOfAttributes { get; set; }

        [FameProperty(Name = "evolutionOfNumberOfMethods")]
        public Number evolutionOfNumberOfMethods { get; set; }

        [FameProperty(Name = "addedNumberOfStatements")]
        public Number addedNumberOfStatements { get; set; }

        [FameProperty(Name = "latestEvolutionOfNumberOfAttributes")]
        public Number latestEvolutionOfNumberOfAttributes { get; set; }

        [FameProperty(Name = "evolutionOfNumberOfStatements")]
        public Number evolutionOfNumberOfStatements { get; set; }

        [FameProperty(Name = "addedNumberOfLinesOfCode")]
        public Number addedNumberOfLinesOfCode { get; set; }

        [FameProperty(Name = "evolutionOfNumberOfAttributes")]
        public Number evolutionOfNumberOfAttributes { get; set; }

        [FameProperty(Name = "earliestEvolutionOfNumberOfLinesOfCode")]
        public Number earliestEvolutionOfNumberOfLinesOfCode { get; set; }

        [FameProperty(Name = "removedNumberOfLinesOfCode")]
        public Number removedNumberOfLinesOfCode { get; set; }

        [FameProperty(Name = "removedNumberOfStatements")]
        public Number removedNumberOfStatements { get; set; }

        [FameProperty(Name = "lastOfNumberOfMethods")]
        public Number lastOfNumberOfMethods { get; set; }







    }
}