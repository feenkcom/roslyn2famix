using Fame;
using System.Collections.Generic;

namespace Model
{
    [FamePackage("FAMIX")]
    [FameDescription("Type")]
    public class Type : NamedEntity
    {

        private List<Method> methods = new List<Method>();

        [FameProperty(Name = "Methods", Opposite = "ParentType")]
        public List<Method> Methods
        {
            get { return methods; }
            set { methods = value; }
        }

        public void AddMethod(Method one)
        {
            methods.Add(one);
        }

        private List<Attribute> attributes = new List<Attribute>();

        [FameProperty(Name = "Attribute", Opposite = "ParentType")]
        public List<Attribute> Attributes
        {
            get { return attributes; }
            set { attributes = value; }
        }

        public void AddAttribute(Attribute one)
        {
            attributes.Add(one);
        }

    }
}