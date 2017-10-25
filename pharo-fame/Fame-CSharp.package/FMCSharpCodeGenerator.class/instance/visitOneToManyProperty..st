visiting
visitOneToManyProperty: fameProperty
	"self initializeProperty: fameProperty with: 'nil'.
	self compileGetter: fameProperty.
	self compileOneToManySetter: fameProperty.	"
	classCodeGenerator visitProperty: fameProperty.