as yet unclassified
generateFor: repository in: folderPath
	self folderPath: folderPath.
	repository packages do: [ :aPackage | 
		self generateForPackage: aPackage ]