using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Method")]
    public class Method : BehaviouralEntity
    {
        private List<DeclaredException> declaredExceptions = new List<DeclaredException>();        [FameProperty(Name = "declaredExceptions", Opposite = "definingMethod")]        public List DeclaredExceptions        {            get { return DeclaredExceptions; }            set { DeclaredExceptions = value; }        }        public void AddDeclaredException(DeclaredException one)        {            DeclaredExceptions.Add(one);        }
        private List<ThrownException> thrownExceptions = new List<ThrownException>();        [FameProperty(Name = "thrownExceptions", Opposite = "definingMethod")]        public List	 ThrownExceptions        {            get { return ThrownExceptions; }            set { ThrownExceptions = value; }        }        public void AddThrownException(ThrownException one)        {            ThrownExceptions.Add(one);        }
        private List<CaughtException> caughtExceptions = new List<CaughtException>();        [FameProperty(Name = "caughtExceptions", Opposite = "definingMethod")]        public List CaughtExceptions        {            get { return CaughtExceptions; }            set { CaughtExceptions = value; }        }        public void AddCaughtException(CaughtException one)        {            CaughtExceptions.Add(one);        }
        [FameProperty(Name = "hasClassScope")]
        public Boolean hasClassScope { get; set; }

        [FameProperty(Name = "parentType") Opposite = "methods"]
        public Type parentType { get; set; }

        [FameProperty(Name = "kind")]
        public String kind { get; set; }

        [FameProperty(Name = "timeStamp")]
        public String timeStamp { get; set; }

        [FameProperty(Name = "category")]
        public String category { get; set; }







    }
}