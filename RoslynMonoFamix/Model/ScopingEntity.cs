using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("ScopingEntity")]
    public class ScopingEntity : ContainerEntity
    {
        [FameProperty(Name = "parentScope") Opposite = "childScopes"]
        public ScopingEntity parentScope { get; set; }

        private List<ScopingEntity> childScopes = new List<ScopingEntity>();        [FameProperty(Name = "childScopes", Opposite = "parentScope")]        public ListchildScopes ScopingEntitys        {            get { return ScopingEntitys; }            set { ScopingEntitys = value; }        }        public void AddScopingEntity(ScopingEntity one)        {            ScopingEntitys.Add(one);        }
        private List<GlobalVariable> globalVariables = new List<GlobalVariable>();        [FameProperty(Name = "globalVariables", Opposite = "parentScope")]        public List GlobalVariables        {            get { return GlobalVariables; }            set { GlobalVariables = value; }        }        public void AddGlobalVariable(GlobalVariable one)        {            GlobalVariables.Add(one);        }






    }
}