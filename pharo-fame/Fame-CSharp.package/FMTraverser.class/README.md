This class traverses the Famix metamodel and accepts visitors on each element in the metamodel.
tower := FMTower new.
tower metamodel importString: FMDungeonExample metamodelString.
traverser := FMTraverser new. 
generator := FMCSharpCodeGeneratorVisitor new.
generator directory: '/Users/george/cs' asFileReference.
traverser accept: generator on: tower metamodel.


generator directory: '/Users/george/moose' asFileReference.
traverser accept: generator on: MooseModel meta.