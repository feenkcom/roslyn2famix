visiting
visitRepository: aMetaRepository
	"Starts visiting a repository, just do the init dance."
	directory ensureCreateDirectory.
	directory deleteAll.
	directory ensureCreateDirectory.
	