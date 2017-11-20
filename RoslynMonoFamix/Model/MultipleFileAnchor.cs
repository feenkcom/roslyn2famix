using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("MultipleFileAnchor")]
    public class MultipleFileAnchor : SourceAnchor
    {
	     private List<AbstractFileAnchor> allFiles = new List<AbstractFileAnchor>();        [FameProperty(Name = "allFiles")]        public List AbstractFileAnchors        {            get { return AbstractFileAnchors; }            set { AbstractFileAnchors = value; }        }        public void AddAbstractFileAnchor(AbstractFileAnchor one)        {            AbstractFileAnchors.Add(one);        }






    }
}