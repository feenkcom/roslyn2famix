visiting
visitClass: class visitor: aVisitor
	"comment stating purpose of message"
	fameClass := class.
	class attributes do: [ :attribute | 
			aVisitor acceptFameProperty: attribute ].
	^ class