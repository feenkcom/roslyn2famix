initialization
initialize
	super initialize.
	instVarNames := OrderedCollection new.
	initializeSource := String new writeStream.