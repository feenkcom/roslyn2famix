using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Type")]
    public class Type : ContainerEntity
    {
        private List<BehaviouralEntity> behavioursWithDeclaredType = new List<BehaviouralEntity>();        [FameProperty(Name = "behavioursWithDeclaredType", Opposite = "declaredType")]        public List<BehaviouralEntity> BehaviouralEntitys        {            get { return BehaviouralEntitys; }            set { BehaviouralEntitys = value; }        }        public void AddBehaviouralEntity(BehaviouralEntity one)        {            BehaviouralEntitys.Add(one);        }
        private List<Attribute> attributes = new List<Attribute>();        [FameProperty(Name = "attributes", Opposite = "parentType")]        public List<Attribute> Attributes        {            get { return Attributes; }            set { Attributes = value; }        }        public void AddAttribute(Attribute one)        {            Attributes.Add(one);        }
        private List<StructuralEntity> structuresWithDeclaredType = new List<StructuralEntity>();        [FameProperty(Name = "structuresWithDeclaredType", Opposite = "declaredType")]        public List<StructuralEntity> StructuralEntitys        {            get { return StructuralEntitys; }            set { StructuralEntitys = value; }        }        public void AddStructuralEntity(StructuralEntity one)        {            StructuralEntitys.Add(one);        }
        private List<Instance> instances = new List<Instance>();        [FameProperty(Name = "instances", Opposite = "type")]        public List Instances        {            get { return Instances; }            set { Instances = value; }        }        public void AddInstance(Instance one)        {            Instances.Add(one);        }
        [FameProperty(Name = "container", Opposite = "types")]
        public ContainerEntity container { get; set; }

        private List<TypeAlias> typeAliases = new List<TypeAlias>();        [FameProperty(Name = "typeAliases", Opposite = "aliasedType")]        public List	 TypeAliass        {            get { return TypeAliass; }            set { TypeAliass = value; }        }        public void AddTypeAlias(TypeAlias one)        {            TypeAliass.Add(one);        }
        private List<Inheritance> superInheritances = new List<Inheritance>();        [FameProperty(Name = "superInheritances", Opposite = "subclass")]        public List Inheritances        {            get { return Inheritances; }            set { Inheritances = value; }        }        public void AddInheritance(Inheritance one)        {            Inheritances.Add(one);        }
        private List<Reference> incomingReferences = new List<Reference>();        [FameProperty(Name = "incomingReferences", Opposite = "target")]        public List References        {            get { return References; }            set { References = value; }        }        public void AddReference(Reference one)        {            References.Add(one);        }
        private List<ParameterizedType> argumentsInParameterizedTypes = new List<ParameterizedType>();        [FameProperty(Name = "argumentsInParameterizedTypes") Opposite = "arguments"]        public List#argumentsInParameterizedTypes ParameterizedTypes        {            get { return ParameterizedTypes; }            set { ParameterizedTypes = value; }        }        public void AddParameterizedType(ParameterizedType one)        {            ParameterizedTypes.Add(one);        }
        private List<Method> methods = new List<Method>();        [FameProperty(Name = "methods", Opposite = "parentType")]        public List Methods        {            get { return Methods; }            set { Methods = value; }        }        public void AddMethod(Method one)        {            Methods.Add(one);        }
        private List<Inheritance> subInheritances = new List<Inheritance>();        [FameProperty(Name = "subInheritances", Opposite = "superclass")]        public List Inheritances        {            get { return Inheritances; }            set { Inheritances = value; }        }        public void AddInheritance(Inheritance one)        {            Inheritances.Add(one);        }






    }
}