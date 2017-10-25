visiting
visitClass: class visitor: vis
	"comment stating purpose of message"
	fameClass := class.
	class attributes do: [ :attribute | 
			vis acceptFameProperty: attribute ].
	^	class