writing
writeAttributeAnnotation: aFM3PropertyDescription 
	self write: '[FameProperty(Name = "', aFM3PropertyDescription name,'"'.
	aFM3PropertyDescription hasOpposite ifTrue: [ theStream nextPutAll: ',  Opposite = "'; nextPutAll: aFM3PropertyDescription opposite name; nextPutAll: '"' ].
	theStream nextPutAll: ')]'.
	self writeLine: ''.
	