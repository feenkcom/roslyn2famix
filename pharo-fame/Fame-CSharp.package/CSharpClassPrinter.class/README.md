I print a meta model class as a C# class. 


        private List<Function> functions = new List<Function>();

        [FameProperty(Name = "functions", Opposite = "container")]
        public List Functions
        {
            get { return Functions; }
            set { Functions = value; }
        }

        public void AddFunction(Function one)
        {
            Functions.Add(one);
        }
