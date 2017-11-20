using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FILE")]
    [FameDescription("Folder")]
    public class Folder : AbstractFile
    {
        private List<AbstractFile> childrenFileSystemEntities = new List<AbstractFile>();        [FameProperty(Name = "childrenFileSystemEntities", Opposite = "parentFolder")]        public List AbstractFiles        {            get { return AbstractFiles; }            set { AbstractFiles = value; }        }        public void AddAbstractFile(AbstractFile one)        {            AbstractFiles.Add(one);        }






    }
}