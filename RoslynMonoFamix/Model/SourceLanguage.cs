using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("SourceLanguage")]
    public class SourceLanguage : Entity
    {
        private List<SourcedEntity> sourcedEntities = new List<SourcedEntity>();        [FameProperty(Name = "sourcedEntities", Opposite = "declaredSourceLanguage")]        public ListsourcedEntities SourcedEntitys        {            get { return SourcedEntitys; }            set { SourcedEntitys = value; }        }        public void AddSourcedEntity(SourcedEntity one)        {            SourcedEntitys.Add(one);        }






    }
}