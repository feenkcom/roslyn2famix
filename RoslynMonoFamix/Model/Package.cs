using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Package")]
    public class Package : ScopingEntity
    {
        private List<NamedEntity> childNamedEntities = new List<NamedEntity>();        [FameProperty(Name = "childNamedEntities", Opposite = "parentPackage")]        public List
 NamedEntitys        {            get { return NamedEntitys; }            set { NamedEntitys = value; }        }        public void AddNamedEntity(NamedEntity one)        {            NamedEntitys.Add(one);        }






    }
}