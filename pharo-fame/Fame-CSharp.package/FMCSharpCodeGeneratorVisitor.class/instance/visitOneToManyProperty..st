visiting
visitOneToManyProperty: fameProperty
	"self initializeProperty: fameProperty with: 'nil'.
	self compileGetter: fameProperty.
	self compileOneToManySetter: fameProperty.	"
	instVars add: ('        [FameProperty(Name = "<1s>", Opposite = "', fameProperty opposite name, '")]<n>',
    					'        public <2s> <1s> { get; set; }<n>'
						expandMacrosWith: fameProperty name with: fameProperty type name).