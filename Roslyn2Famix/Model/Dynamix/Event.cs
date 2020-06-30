using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace Dynamix
{
    [FamePackage("Dynamix")]
    [FameDescription("Event")]
    public class Event : Dynamix.Entity
    {
        private List<Dynamix.Event> children = new List<Dynamix.Event>();

        [FameProperty(Name = "children", Opposite = "parent")]
        public List<Dynamix.Event> Children
        {
            get { return children; }
            set { children = value; }
        }
        public void AddChildren(Dynamix.Event one)
        {
            children.Add(one);
        }

        [FameProperty(Name = "parent", Opposite = "children")]
        public Dynamix.Event parent { get; set; }

    }
}
