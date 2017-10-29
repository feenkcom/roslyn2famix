visiting
visitClass: aFameClass
	| file |
	file := directory / (aFameClass name capitalized, '.cs').
	file ensureCreateFile.
	self fameClass: aFameClass.
	file writeStreamDo: [ : aStream | 
			self stream: aStream.
			stream nextPutAll: self buildClassDefinition.
			].