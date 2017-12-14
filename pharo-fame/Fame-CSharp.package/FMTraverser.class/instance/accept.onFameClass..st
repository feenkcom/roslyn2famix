accepting
accept: visitor onFameClass: fameClass
	fameClass attributes  do: [ :prop |
		self accept: visitor onFameProperty: prop ].
	visitor visitClass: fameClass.
