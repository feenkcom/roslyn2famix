accepting
accept: visitor onFameClass: fameClass
	visitor visitClass: fameClass.
	fameClass attributes  do: [ :prop |
		self accept: visitor onFameProperty: prop ].
	
