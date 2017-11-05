visiting
visitManyProperty: fameProperty
	"self initializeProperty: fameProperty with: 'OrderedCollection new'.
	self compileGetter: fameProperty.
	self compileSimpleSetter: fameProperty.	"
	|typeName|
	typeName := fameProperty type name.
	instVars add: ('
	     private List%<<1s>> <2s> = new List%<<1s>>();

        [FameProperty(Name = "<2s>")]
        public List<',typeName,'> ',typeName,'s
        {
            get { return ',typeName,'s; }
            set { ',typeName,'s = value; }
        }

        public void Add<1s>(',typeName,' one)
        {
            ',typeName,'s.Add(one);
        }' expandMacrosWith: fameProperty type name with:fameProperty name).