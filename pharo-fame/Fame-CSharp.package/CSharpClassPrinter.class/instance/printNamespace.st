printing
printNamespace
	self writeLine: 'namespace ', theClass packageName.
	self enterBlock.
	self printClass.
	self exitBlock.