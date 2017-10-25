visiting
visit: aMetaRepository 
   directory ensureDelete.
	directory ensureCreateDirectory.
	aMetaRepository packages do: [ :each |
		self acceptFamePackage: each ]