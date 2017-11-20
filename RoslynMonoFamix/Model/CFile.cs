using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("CFile")]
    public class CFile : File
    {
        private List<Include> incomingIncludeRelations = new List<Include>();        [FameProperty(Name = "incomingIncludeRelations", Opposite = "target")]        public List Includes        {            get { return Includes; }            set { Includes = value; }        }        public void AddInclude(Include one)        {            Includes.Add(one);        }
        private List<Include> outgoingIncludeRelations = new List<Include>();        [FameProperty(Name = "outgoingIncludeRelations", Opposite = "source")]        public List Includes        {            get { return Includes; }            set { Includes = value; }        }        public void AddInclude(Include one)        {            Includes.Add(one);        }






    }
}