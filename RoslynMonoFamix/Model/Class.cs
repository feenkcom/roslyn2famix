using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Class")]
    public class Class : Type
    {
        [FameProperty(Name = "isInterface")]
        public Boolean isInterface { get; set; }

        private List<Exception> exceptions = new List<Exception>();        [FameProperty(Name = "exceptions", Opposite = "exceptionClass")]        public List Exceptions        {            get { return Exceptions; }            set { Exceptions = value; }        }        public void AddException(Exception one)        {            Exceptions.Add(one);        }






    }
}