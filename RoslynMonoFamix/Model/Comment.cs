using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Comment")]
    public class Comment : SourcedEntity
    {
        [FameProperty(Name = "content")]
        public String content { get; set; }

        [FameProperty(Name = "container") Opposite = "comments"]
        public SourcedEntity container { get; set; }







    }
}