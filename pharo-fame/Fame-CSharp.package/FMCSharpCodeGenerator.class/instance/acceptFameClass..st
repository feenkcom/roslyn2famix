accepting
acceptFameClass: fameClass
	self visitClass: fameClass.
	fameClass attributes do: [ :attribute | 
		self acceptFameProperty: attribute ].
	self visitClassDone: fameClass.