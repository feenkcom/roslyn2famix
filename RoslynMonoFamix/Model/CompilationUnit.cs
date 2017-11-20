using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("CompilationUnit")]
    public class CompilationUnit : CFile
    {
        [FameProperty(Name = "module") Opposite = "compilationUnit"]
        public Module module { get; set; }







    }
}