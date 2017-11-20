using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Dude")]
    [FameDescription("Multiplication")]
    public class Multiplication : Entity
    {
        private List<Duplication> duplications = new List<Duplication>();        [FameProperty(Name = "duplications", Opposite = "multiplicationInvolved")]        public List Duplications        {            get { return Duplications; }            set { Duplications = value; }        }        public void AddDuplication(Duplication one)        {            Duplications.Add(one);        }






    }
}