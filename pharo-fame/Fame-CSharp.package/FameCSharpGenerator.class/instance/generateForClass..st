as yet unclassified
generateForClass: aFameClass 
	| file |
	file := folderPath / (aFameClass name capitalized, '.cs').
	file ensureCreateFile.
	file writeStreamDo: [ : aStream | 
			CSharpClassPrinter new print: aFameClass in: aStream
			].