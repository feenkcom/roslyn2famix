printing
printClass
	self writeLine: '[FamePackage("', theClass package name, '")]'.
	self writeLine: '[FameDescription("', theClass name, '")]'.
	theClass superclass name = 'Object' ifTrue: [self writeLine: 'public class ', theClass name]; 
	ifFalse: [self writeLine: 'public class ', theClass name, ' : ', theClass superclass package name, '.', theClass superclass  name].
	self enterBlock.
	self printAttributes.
	self exitBlock.
	
	