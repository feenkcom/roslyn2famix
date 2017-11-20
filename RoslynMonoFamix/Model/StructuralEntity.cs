using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("StructuralEntity")]
    public class StructuralEntity : LeafEntity
    {
        [FameProperty(Name = "declaredType") Opposite = "structuresWithDeclaredType"]
        public Type declaredType { get; set; }

        private List<DereferencedInvocation> dereferencedInvocations = new List<DereferencedInvocation>();        [FameProperty(Name = "dereferencedInvocations", Opposite = "referencer")]        public List DereferencedInvocations        {            get { return DereferencedInvocations; }            set { DereferencedInvocations = value; }        }        public void AddDereferencedInvocation(DereferencedInvocation one)        {            DereferencedInvocations.Add(one);        }
        private List<Access> incomingAccesses = new List<Access>();        [FameProperty(Name = "incomingAccesses", Opposite = "variable")]        public List Accesss        {            get { return Accesss; }            set { Accesss = value; }        }        public void AddAccess(Access one)        {            Accesss.Add(one);        }






    }
}