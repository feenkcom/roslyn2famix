using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Function")]
    public class Function : FAMIX.BehaviouralEntity
    {
        [FameProperty(Name = "container", Opposite = "functions")]
        public FAMIX.ContainerEntity container { get; set; }

        [FameProperty(Name = "parentModule")]
        public FAMIX.VBModule parentModule { get; set; }

    }
}
