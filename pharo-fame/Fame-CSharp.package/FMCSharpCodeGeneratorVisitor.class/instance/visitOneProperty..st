visiting
visitOneProperty: fameProperty
	"self initializeProperty: fameProperty with: 'nil'.
	self compileGetter: fameProperty.
	self compileSimpleSetter: fameProperty.	"
	instVars add: ('        [FameProperty(Name = "<1s>")]<n>',
    					'        public <2s> <1s> { get; set; }<n>'
						expandMacrosWith: fameProperty name with: fameProperty type name).