printing
printNamespace
	self writeLine: 'namespace ', theClass package name.
	self enterBlock.
	self printClass.
	self exitBlock.