using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("CFile")]
    public class CFile : FILE.File
    {
        private List<FAMIX.Include> incomingIncludeRelations = new List<FAMIX.Include>();

        [FameProperty(Name = "incomingIncludeRelations", Opposite = "target")]
        public List<FAMIX.Include> IncomingIncludeRelations
        {
            get { return incomingIncludeRelations; }
            set { incomingIncludeRelations = value; }
        }
        public void AddIncomingIncludeRelation(FAMIX.Include one)
        {
            incomingIncludeRelations.Add(one);
        }

        private List<FAMIX.Include> outgoingIncludeRelations = new List<FAMIX.Include>();

        [FameProperty(Name = "outgoingIncludeRelations", Opposite = "source")]
        public List<FAMIX.Include> OutgoingIncludeRelations
        {
            get { return outgoingIncludeRelations; }
            set { outgoingIncludeRelations = value; }
        }
        public void AddOutgoingIncludeRelation(FAMIX.Include one)
        {
            outgoingIncludeRelations.Add(one);
        }

    }
}
