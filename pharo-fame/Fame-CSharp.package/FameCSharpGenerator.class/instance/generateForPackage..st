as yet unclassified
generateForPackage: aFM3PackageDescription 
	|save|
	save := folderPath.
	folderPath := folderPath / aFM3PackageDescription name.
	folderPath ensureCreateDirectory.
	aFM3PackageDescription classes do: [ :aClass | 
		self generateForClass: aClass
		 ].
	folderPath := save.