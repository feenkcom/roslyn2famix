generating
buildClassDefinition
	^ (String streamContents: [ :stream |
		stream
			nextPutAll: '<1s><n><n>'; "Package definition"
			nextPutAll: '<2s><n><n>'; "Imports"
			nextPutAll: '<3s><n>';    "Annotations"
			nextPutAll: '<4s><n>';    "Class signature"
			nextPutAll: '{<n>';    
			nextPutAll: '<5s><n><n>'; "Attributes"
			nextPutAll: '<6s><n><n>'; "Construtor"
			nextPutAll: '<7s><n><n>'; "Content"
			nextPutAll: '}']) expandMacrosWithArguments: { 
				self buildPackageDefinition.
				self buildImports.
				self buildClassAnnotations.
				self buildClassSignature.
				self buildAttributesDefinitions.
				self buildClassConstrutor.
				self buildClassContent
		 } 