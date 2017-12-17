printing
printAttributes
		|wrongAttributes|
		wrongAttributes := OrderedCollection  new.
		theClass attributes  do: [ :prop |
			[ 
			"we only want attributes that have a corresponding setter"
         theClass implementingClass methodNamed: (prop implementingSelector asMutator).
			"the line above tries to access the setter, if it does not find id an exception happens"
			self printAttribute: prop.
			] on: KeyNotFound do: [ wrongAttributes add: prop ].
		]. 	