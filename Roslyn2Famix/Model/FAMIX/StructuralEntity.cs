using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("StructuralEntity")]
    public class StructuralEntity : FAMIX.LeafEntity
    {
        [FameProperty(Name = "declaredType", Opposite = "structuresWithDeclaredType")]
        public FAMIX.Type declaredType { get; set; }

        private List<FAMIX.Access> incomingAccesses = new List<FAMIX.Access>();

        [FameProperty(Name = "incomingAccesses", Opposite = "variable")]
        public List<FAMIX.Access> IncomingAccesses
        {
            get { return incomingAccesses; }
            set { incomingAccesses = value; }
        }
        public void AddIncomingAccesse(FAMIX.Access one)
        {
            incomingAccesses.Add(one);
        }

    }
}
