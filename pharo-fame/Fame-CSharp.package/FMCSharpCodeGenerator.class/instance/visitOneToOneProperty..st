visiting
visitOneToOneProperty: fameProperty
	"self initializeProperty: fameProperty with: 'nil'.
	self compileGetter: fameProperty.
	self compileOneToOneSetter: fameProperty."	
	file writeStreamDo: [ :aStream | 
		aStream nextPutAll: fameProperty name. aStream nextPutAll: '  '].