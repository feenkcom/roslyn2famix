using Dynamix;
using Fame;
using FAMIX;
using FILE;
using System;
using System.Collections.Generic;

namespace FAMIX
{
    [FamePackage("FAMIX")]
    [FameDescription("SourceLanguage")]
    public class SourceLanguage : FAMIX.Entity
    {
        private List<FAMIX.SourcedEntity> sourcedEntities = new List<FAMIX.SourcedEntity>();

        [FameProperty(Name = "sourcedEntities", Opposite = "declaredSourceLanguage")]
        public List<FAMIX.SourcedEntity> SourcedEntities
        {
            get { return sourcedEntities; }
            set { sourcedEntities = value; }
        }
        public void AddSourcedEntitie(FAMIX.SourcedEntity one)
        {
            sourcedEntities.Add(one);
        }

    }
}
