visiting
visitOneToOneProperty: fameProperty
	"self initializeProperty: fameProperty with: 'nil'.
	self compileGetter: fameProperty.
	self compileOneToOneSetter: fameProperty."	
	stream nextPutAll: fameProperty name, ' '.