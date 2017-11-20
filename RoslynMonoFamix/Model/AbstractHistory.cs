using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Hismo")]
    [FameDescription("AbstractHistory")]
    public class AbstractHistory : Entity
    {
        [FameProperty(Name = "age")]
        public Number age { get; set; }







    }
}