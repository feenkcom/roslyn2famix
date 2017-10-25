visiting
visitClass: fameClass
	| classDefinition |
	classCodeGenerator := FMCSharpClassCodeGenerator forFameClass: fameClass.
	classDefinition := classCodeGenerator buildClassDefinition.
	file writeStreamDo: [ :aStream | 
		aStream nextPutAll: classDefinition ].