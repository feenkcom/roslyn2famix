using Fame;

namespace Model
{
    [FamePackage("FAMIX")]
    [FameDescription("Method")]
    class Method
    {

        [FameProperty(Name = "Kind")]
        public string Kind { get; set; }

    }
}