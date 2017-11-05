visiting
visitManyToManyProperty: fameProperty 
	"self initializeProperty: fameProperty with: ('FMMultiMultivalueLink on: self opposite: #<1s>' 
		expandMacrosWith: (self methodNameFor: fameProperty opposite)).
	self compileGetter: fameProperty.
	self compileManyToAnySetter: fameProperty."
	|typeName|
	typeName := fameProperty type name.
	instVars add: ('
        private List%<<1s>> <2s> = new List%<<1s>>();

        [FameProperty(Name = "<2s>") Opposite = "', fameProperty opposite name, '"]
        public List<',typeName,'> ',typeName,'s
        {
            get { return ',typeName,'s; }
            set { ',typeName,'s = value; }
        }

        public void Add<1s>(',typeName,' one)
        {
            ',typeName,'s.Add(one);
        }' expandMacrosWith: fameProperty type name with:fameProperty name).