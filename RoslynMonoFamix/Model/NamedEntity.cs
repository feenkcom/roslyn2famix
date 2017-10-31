using Fame;

namespace Model
{
    [FamePackage("FAMIX")]
    [FameDescription("NamedEntity")]
    public class NamedEntity
    {

        [FameProperty(Name = "Name")]
        public string Name { get; set; }

    }
}