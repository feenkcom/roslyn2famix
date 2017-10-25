visiting
visitOneToManyProperty: fameProperty
	"self initializeProperty: fameProperty with: 'nil'.
	self compileGetter: fameProperty.
	self compileOneToManySetter: fameProperty.	"
	file writeStreamDo: [ :aStream | 
		aStream nextPutAll: fameProperty name ].