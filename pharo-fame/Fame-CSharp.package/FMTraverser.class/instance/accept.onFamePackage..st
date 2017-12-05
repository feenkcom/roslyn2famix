accepting
accept: visitor onFamePackage: aFamePackage
	"comment stating purpose of message"
	visitor visitPackage: aFamePackage.
	(aFamePackage name includesSubstring: 'FAMIX') ifTrue: 
	 [  
	  aFamePackage classes do: [ :fameClass |
		 self accept: visitor onFameClass: fameClass ]
	 ].
			 