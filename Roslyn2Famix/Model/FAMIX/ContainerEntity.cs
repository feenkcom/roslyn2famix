using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("ContainerEntity")]
    public class ContainerEntity : FAMIX.NamedEntity
    {
        private List<FAMIX.AnnotationType> definedAnnotationTypes = new List<FAMIX.AnnotationType>();

        [FameProperty(Name = "definedAnnotationTypes", Opposite = "container")]
        public List<FAMIX.AnnotationType> DefinedAnnotationTypes
        {
            get { return definedAnnotationTypes; }
            set { definedAnnotationTypes = value; }
        }
        public void AddDefinedAnnotationType(FAMIX.AnnotationType one)
        {
            definedAnnotationTypes.Add(one);
        }

        private List<FAMIX.Function> functions = new List<FAMIX.Function>();

        [FameProperty(Name = "functions", Opposite = "container")]
        public List<FAMIX.Function> Functions
        {
            get { return functions; }
            set { functions = value; }
        }
        public void AddFunction(FAMIX.Function one)
        {
            functions.Add(one);
        }

        private List<FAMIX.Type> types = new List<FAMIX.Type>();

        [FameProperty(Name = "types", Opposite = "container")]
        public List<FAMIX.Type> Types
        {
            get { return types; }
            set { types = value; }
        }
        public void AddType(FAMIX.Type one)
        {
            types.Add(one);
        }

    }
}
