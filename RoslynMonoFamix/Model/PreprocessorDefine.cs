using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("PreprocessorDefine")]
    public class PreprocessorDefine : PreprocessorStatement
    {
        [FameProperty(Name = "macro")]
        public String macro { get; set; }







    }
}