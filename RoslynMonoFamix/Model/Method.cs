using Fame;

namespace Model
{
    [FamePackage("FAMIX")]
    [FameDescription("Method")]
    public class Method : BehaviouralEntity
    {

        [FameProperty(Name = "Kind")]
        public string Kind { get; set; }

    }
}