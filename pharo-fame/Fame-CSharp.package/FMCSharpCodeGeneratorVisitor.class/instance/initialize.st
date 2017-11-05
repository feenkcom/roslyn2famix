initialization
initialize
	super initialize.
	instVars := OrderedCollection new.
	initializeSource := String new writeStream.