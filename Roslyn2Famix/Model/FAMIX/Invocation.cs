using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("Invocation")]
    public class Invocation : FAMIX.Association
    {
        private List<FAMIX.BehaviouralEntity> candidates = new List<FAMIX.BehaviouralEntity>();

        [FameProperty(Name = "candidates", Opposite = "incomingInvocations")]
        public List<FAMIX.BehaviouralEntity> Candidates
        {
            get { return candidates; }
            set { candidates = value; }
        }
        public void AddCandidate(FAMIX.BehaviouralEntity one)
        {
            candidates.Add(one);
        }

        [FameProperty(Name = "receiver", Opposite = "receivingInvocations")]
        public FAMIX.NamedEntity receiver { get; set; }

        [FameProperty(Name = "sender", Opposite = "outgoingInvocations")]
        public FAMIX.BehaviouralEntity sender { get; set; }

        [FameProperty(Name = "signature")]
        public String signature { get; set; }

    }
}
