accepting
acceptFameProperty: fameProperty
	| selector |
	
	selector := String new writeStream.
	selector nextPutAll: 'visit'.
	fameProperty isDerived
		ifTrue: [ selector nextPutAll: 'Derived' ].
	fameProperty isMultivalued
		ifTrue: [ selector nextPutAll: 'Many' ]
		ifFalse: [ selector nextPutAll: 'One' ].
	fameProperty hasOpposite
		ifTrue: [ selector nextPutAll: 'To'.
			fameProperty opposite isMultivalued
				ifTrue: [ selector nextPutAll: 'Many' ]
				ifFalse: [ selector nextPutAll: 'One' ]].
	selector nextPutAll: 'Property:'.
	self perform: selector contents asSymbol with: fameProperty.