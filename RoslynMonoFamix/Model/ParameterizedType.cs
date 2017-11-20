using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("ParameterizedType")]
    public class ParameterizedType : Type
    {
        private List<Type> arguments = new List<Type>();        [FameProperty(Name = "arguments") Opposite = "argumentsInParameterizedTypes"]        public List	 Types        {            get { return Types; }            set { Types = value; }        }        public void AddType(Type one)        {            Types.Add(one);        }
        [FameProperty(Name = "parameterizableClass") Opposite = "parameterizedTypes"]
        public ParameterizableClass parameterizableClass { get; set; }







    }
}