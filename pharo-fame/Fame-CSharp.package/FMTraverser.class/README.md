This class traverses the Famix metamodel and accepts visitors on each element in the metamodel.

traverser := FMTraverser new. 
generator := FMCSharpCodeGeneratorVisitor new.
generator directory: '/Users/george/moose' asFileReference.
traverser accept: generator on: MooseModel meta.