using Fame;
using System.Collections.Generic;

namespace Model
{
    [FamePackage("FAMIX")]
    [FameDescription("Type")]
    class Type
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

    }
}