visiting
visit: aMetaRepository 
	aMetaRepository packages do: [ :each |
		self acceptFamePackage:  each ]