This class traverses the Famix metamodel and accepts visitors on each element in the metamodel.
tower := FMTower new.
tower metamodel importString: FMDungeonExample metamodelString.
generator := FMCSharpCodeGenerator new.
generator visit: tower metamodel.

generator := FMCSharpCodeGenerator new.
generator visit: MooseModel meta.

directory := '.' asFileReference / 'dungeon'.
directory ensureCreateDirectory.
file := directory / 'Test.cs'.
file ensureCreateFile.
file writeStreamDo: [ :aStream | 
	aStream nextPutAll: 'test' ].