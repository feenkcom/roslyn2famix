accepting
acceptFameClass: fameClass
	file := directory / (fameClass name capitalized, '.cs').
	file ensureDelete.
	file ensureCreateFile.
	file writeStreamDo: [ :stream | 
		classCodeGenerator := FMCSharpCodeGeneratorVisitor new 
			stream: stream.
			classCodeGenerator visitClass: fameClass visitor:self.
			stream nextPutAll: (classCodeGenerator buildClassDefinition).
			].
	
