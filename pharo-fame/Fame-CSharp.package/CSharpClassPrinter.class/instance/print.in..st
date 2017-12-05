printing
print: aClass in: aStream
	theStream := aStream.
	theClass := aClass.
	indent := 0.
	self printUsings.
	self printNamespace.