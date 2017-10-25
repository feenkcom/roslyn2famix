accepting
acceptFameClass: fameClass
	file := directory / (fameClass name capitalized, '.cs').
	file ensureDelete.
	file ensureCreateFile.
	file writeStreamDo: [ :stream | 
		classCodeGenerator := FMCSharpClassCodeGenerator new 
			stream: stream.
			classCodeGenerator visitClass: fameClass visitor:self.
			stream nextPutAll: (classCodeGenerator buildClassDefinition).
			].
	
