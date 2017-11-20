using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Function")]
    public class Function : BehaviouralEntity
    {
        [FameProperty(Name = "container") Opposite = "functions"]
        public ContainerEntity container { get; set; }

        [FameProperty(Name = "parentModule")]
        public Module parentModule { get; set; }







    }
}