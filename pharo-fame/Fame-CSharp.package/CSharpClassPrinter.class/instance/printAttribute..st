printing
printAttribute: fameProperty
	|propName propType|
	fameProperty package = fameProperty class package ifTrue: [ 
	propName := fameProperty name.
	propType := fameProperty type name.
	propType = 'Number' ifTrue: [ propType := 'int' ].
	fameProperty isMultivalued
		ifTrue: [
					self writeLine: ('private List%<<2s>> <1s> = new List%<<2s>>();' 						expandMacrosWith: (propName) with: propType).
					self writeLine: ''.						
					self writeAttributeAnnotation: fameProperty.
					self writeLine: ('public List %<<1s>> ' expandMacrosWith: propType) , propName capitalized.
					self enterBlock.
						self writeLine: 'get { return ', propName capitalized,  '; }'.
            			self writeLine: 'set { ', propName capitalized,  ' = value; }'.				
					self exitBlock.		
					self writeLine: 'public void Add', (propName capitalized withoutSuffix: 's'), '(', propType, ' one)'.
					self enterBlock.
						self writeLine: propName capitalized, '.Add(one);'.
					self exitBlock.	
			 ]
		ifFalse: [ 
				  self writeAttributeAnnotation: fameProperty.
				  self writeLine: 'public ', propType,' ', propName, ' { get; set; }'
			 ].
		self writeLine: ''.
		].
