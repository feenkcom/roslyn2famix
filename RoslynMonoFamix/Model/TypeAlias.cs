using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("TypeAlias")]
    public class TypeAlias : Type
    {
        [FameProperty(Name = "aliasedType") Opposite = "typeAliases"]
        public Type aliasedType { get; set; }







    }
}