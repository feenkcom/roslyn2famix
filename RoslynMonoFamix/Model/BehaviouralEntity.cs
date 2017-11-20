using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("BehaviouralEntity")]
    public class BehaviouralEntity : ContainerEntity
    {
        private List<Activation> activations = new List<Activation>();        [FameProperty(Name = "activations", Opposite = "behaviour")]        public List Activations        {            get { return Activations; }            set { Activations = value; }        }        public void AddActivation(Activation one)        {            Activations.Add(one);        }
        private List<Access> accesses = new List<Access>();        [FameProperty(Name = "accesses", Opposite = "accessor")]        public List Accesss        {            get { return Accesss; }            set { Accesss = value; }        }        public void AddAccess(Access one)        {            Accesss.Add(one);        }
        [FameProperty(Name = "signature")]
        public String signature { get; set; }

        [FameProperty(Name = "cyclomaticComplexity")]
        public Number cyclomaticComplexity { get; set; }

        private List<LocalVariable> localVariables = new List<LocalVariable>();        [FameProperty(Name = "localVariables", Opposite = "parentBehaviouralEntity")]        public List LocalVariables        {            get { return LocalVariables; }            set { LocalVariables = value; }        }        public void AddLocalVariable(LocalVariable one)        {            LocalVariables.Add(one);        }
        [FameProperty(Name = "declaredType") Opposite = "behavioursWithDeclaredType"]
        public Type declaredType { get; set; }

        private List<Reference> outgoingReferences = new List<Reference>();        [FameProperty(Name = "outgoingReferences", Opposite = "source")]        public List References        {            get { return References; }            set { References = value; }        }        public void AddReference(Reference one)        {            References.Add(one);        }
        private List<ImplicitVariable> implicitVariables = new List<ImplicitVariable>();        [FameProperty(Name = "implicitVariables", Opposite = "parentBehaviouralEntity")]        public List ImplicitVariables        {            get { return ImplicitVariables; }            set { ImplicitVariables = value; }        }        public void AddImplicitVariable(ImplicitVariable one)        {            ImplicitVariables.Add(one);        }
        private List<Invocation> outgoingInvocations = new List<Invocation>();        [FameProperty(Name = "outgoingInvocations", Opposite = "sender")]        public List Invocations        {            get { return Invocations; }            set { Invocations = value; }        }        public void AddInvocation(Invocation one)        {            Invocations.Add(one);        }
        [FameProperty(Name = "numberOfConditionals")]
        public Number numberOfConditionals { get; set; }

        [FameProperty(Name = "numberOfLinesOfCode")]
        public Number numberOfLinesOfCode { get; set; }

        private List<Invocation> incomingInvocations = new List<Invocation>();        [FameProperty(Name = "incomingInvocations") Opposite = "candidates"]        public List Invocations        {            get { return Invocations; }            set { Invocations = value; }        }        public void AddInvocation(Invocation one)        {            Invocations.Add(one);        }
        [FameProperty(Name = "numberOfStatements")]
        public Number numberOfStatements { get; set; }

        private List<Parameter> parameters = new List<Parameter>();        [FameProperty(Name = "parameters", Opposite = "parentBehaviouralEntity")]        public List#parameters Parameters        {            get { return Parameters; }            set { Parameters = value; }        }        public void AddParameter(Parameter one)        {            Parameters.Add(one);        }






    }
}