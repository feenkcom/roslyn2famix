accepting
acceptFamePackage: famePackage
	self visitPackage: famePackage.
	famePackage classes do: [ :fameClass |
		self acceptFameClass: fameClass ]