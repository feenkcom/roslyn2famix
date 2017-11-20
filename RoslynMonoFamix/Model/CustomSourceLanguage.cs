using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("CustomSourceLanguage")]
    public class CustomSourceLanguage : SourceLanguage
    {
        [FameProperty(Name = "name")]
        public String name { get; set; }







    }
}