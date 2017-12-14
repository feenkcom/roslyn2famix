accepting
accept: visitor on: aMetaRepository
	"accepts a visitor and walks it through all packages and classes"
		visitor visitRepository: aMetaRepository.
		aMetaRepository packages do: [ :each |
			self accept: visitor onFamePackage: each ]