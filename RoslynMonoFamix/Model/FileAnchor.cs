using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("FileAnchor")]
    public class FileAnchor : AbstractFileAnchor
    {
        [FameProperty(Name = "endColumn")]
        public Number endColumn { get; set; }

        [FameProperty(Name = "startLine")]
        public Number startLine { get; set; }

        [FameProperty(Name = "startColumn")]
        public Number startColumn { get; set; }

        [FameProperty(Name = "endLine")]
        public Number endLine { get; set; }







    }
}