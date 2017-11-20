using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("AbstractFileAnchor")]
    public class AbstractFileAnchor : SourceAnchor
    {
        [FameProperty(Name = "fileName")]
        public String fileName { get; set; }

        [FameProperty(Name = "correspondingFile")]
        public File correspondingFile { get; set; }

        [FameProperty(Name = "encoding")]
        public String encoding { get; set; }







    }
}