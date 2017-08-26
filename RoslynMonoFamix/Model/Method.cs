using Fame;

namespace Model
{
    [FamePackage("FAMIX")]
    [FameDescription("Method")]
    class Method : NamedEntity
    {

        [FameProperty(Name = "Kind")]
        public string Kind { get; set; }

    }
}