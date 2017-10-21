private - generating
buildClassSignature
	^ ('public', ' ',
	  (fameClass isAbstract ifTrue: [ 'abstract', ' ' ] ifFalse: ['']),
	  'class <1s> : <2s>')
		  expandMacrosWith: fameClass name
						  with: fameClass superclass fullName.