using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FILE")]
    [FameDescription("File")]
    public class File : AbstractFile
    {
        private List<SourcedEntity> entities = new List<SourcedEntity>();        [FameProperty(Name = "entities") Opposite = "containerFiles"]        public Listentities SourcedEntitys        {            get { return SourcedEntitys; }            set { SourcedEntitys = value; }        }        public void AddSourcedEntity(SourcedEntity one)        {            SourcedEntitys.Add(one);        }






    }
}