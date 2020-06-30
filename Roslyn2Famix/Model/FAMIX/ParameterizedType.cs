using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("ParameterizedType")]
    public class ParameterizedType : FAMIX.Type
    {
        private List<FAMIX.Type> arguments = new List<FAMIX.Type>();

        [FameProperty(Name = "arguments", Opposite = "argumentsInParameterizedTypes")]
        public List<FAMIX.Type> Arguments
        {
            get { return arguments; }
            set { arguments = value; }
        }
        public void AddArgument(FAMIX.Type one)
        {
            arguments.Add(one);
        }

        [FameProperty(Name = "parameterizableClass", Opposite = "parameterizedTypes")]
        public FAMIX.ParameterizableClass parameterizableClass { get; set; }

    }
}
