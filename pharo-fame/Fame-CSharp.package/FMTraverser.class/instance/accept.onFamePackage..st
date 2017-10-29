accepting
accept: visitor onFamePackage: aFamePackage
	"comment stating purpose of message"
	visitor visitPackage: aFamePackage.
	aFamePackage classes do: [ :fameClass |
		self accept: visitor onFameClass: fameClass ]