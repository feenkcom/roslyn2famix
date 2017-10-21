visiting
visitClassDone: fameClass 
	| classDefinition directory file |
	
	classDefinition := classCodeGenerator buildClassDefinition.
	directory := '.' asFileReference / 'dungeon'.
	directory ensureCreateDirectory.
	file := directory / (fameClass name capitalized, '.cs').
	file ensureDelete.
	file ensureCreateFile.
	file writeStreamDo: [ :aStream | 
		aStream nextPutAll: classDefinition ].