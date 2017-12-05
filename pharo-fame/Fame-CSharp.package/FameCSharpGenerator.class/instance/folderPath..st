setter
folderPath: aString 
	folderPath := aString asFileReference.
	folderPath ensureCreateDirectory.
	folderPath ensureDeleteAll.
	folderPath ensureCreateDirectory.