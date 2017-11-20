using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("SourcedEntity")]
    public class SourcedEntity : Entity
    {
        [FameProperty(Name = "declaredSourceLanguage") Opposite = "sourcedEntities"]
        public SourceLanguage declaredSourceLanguage { get; set; }

        private List<File> containerFiles = new List<File>();        [FameProperty(Name = "containerFiles") Opposite = "entities"]        public List Files        {            get { return Files; }            set { Files = value; }        }        public void AddFile(File one)        {            Files.Add(one);        }
        private List<Comment> comments = new List<Comment>();        [FameProperty(Name = "comments", Opposite = "container")]        public List Comments        {            get { return Comments; }            set { Comments = value; }        }        public void AddComment(Comment one)        {            Comments.Add(one);        }






    }
}