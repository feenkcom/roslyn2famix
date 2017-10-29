private - generating
buildClassAnnotations

	^ '[FamePackage("<1s>")]<n>',
	 '[FameDescription("<2s>")]' 
		expandMacrosWith: fameClass package name
						with: fameClass name