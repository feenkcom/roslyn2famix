using Fame;

namespace Model
{
    [FamePackage("FAMIX")]
    [FameDescription("Class")]
    class Class : Type
    {

        [FameProperty(Name = "IsInterface")]
        public string IsInterface { get; set; }

    }
}