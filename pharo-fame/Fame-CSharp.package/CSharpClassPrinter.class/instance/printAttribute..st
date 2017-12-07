printing
printAttribute: fameProperty
	|propName propType|
	propName := fameProperty name.
	propType := fameProperty type name.
	(propName = 'activations') | (propName = 'instances') | (propType = 'Number') ifFalse: [ 
	fameProperty isMultivalued
		ifTrue: [
					self writeLine: ('private List%<<2s>> <1s> = new List%<<2s>>();' 						expandMacrosWith: (propName) with: propType).
					self writeLine: ''.						
					self writeAttributeAnnotation: fameProperty.
					self writeLine: ('public List %<<1s>> ' expandMacrosWith: propType) , propName capitalized.
					self enterBlock.
						self writeLine: 'get { return ', propName,  '; }'.
            			self writeLine: 'set { ', propName,  ' = value; }'.				
					self exitBlock.		
					self writeLine: 'public void Add', (propName capitalized withoutSuffix: 's'), '(', propType, ' one)'.
					self enterBlock.
						self writeLine: propName, '.Add(one);'.
					self exitBlock.	
			 ]
		ifFalse: [ 
				  self writeAttributeAnnotation: fameProperty.
				  self writeLine: 'public ', propType,' ', propName, ' { get; set; }'
			 ].
		self writeLine: ''.
 		].