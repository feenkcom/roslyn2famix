using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("ParameterizableClass")]
    public class ParameterizableClass : Class
    {
        private List<ParameterizedType> parameterizedTypes = new List<ParameterizedType>();        [FameProperty(Name = "parameterizedTypes", Opposite = "parameterizableClass")]        public List#parameterizedTypes ParameterizedTypes        {            get { return ParameterizedTypes; }            set { ParameterizedTypes = value; }        }        public void AddParameterizedType(ParameterizedType one)        {            ParameterizedTypes.Add(one);        }






    }
}