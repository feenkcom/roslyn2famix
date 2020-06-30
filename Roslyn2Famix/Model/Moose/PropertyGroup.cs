using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace Moose
{
    [FamePackage("Moose")]
    [FameDescription("PropertyGroup")]
    public class PropertyGroup : Moose.Group
    {
        [FameProperty(Name = "property")]
        public String property { get; set; }

    }
}
