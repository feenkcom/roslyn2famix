using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("DereferencedInvocation")]
    public class DereferencedInvocation : Invocation
    {
        [FameProperty(Name = "referencer") Opposite = "dereferencedInvocations"]
        public StructuralEntity referencer { get; set; }







    }
}