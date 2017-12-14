private - generating
buildAttributesDefinitions
	^ instVars flatCollect: [:var | var, '<n>' expandMacros ].