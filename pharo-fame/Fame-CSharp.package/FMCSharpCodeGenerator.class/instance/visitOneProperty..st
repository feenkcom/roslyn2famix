visiting
visitOneProperty: fameProperty
	"self initializeProperty: fameProperty with: 'nil'.
	self compileGetter: fameProperty.
	self compileSimpleSetter: fameProperty.	"
	file writeStreamDo: [ :aStream | 
		aStream nextPutAll: fameProperty name ].