printing
printNamespace
	self writeLine: 'namespace FAMIX'.
	self enterBlock.
	self printClass.
	self exitBlock.