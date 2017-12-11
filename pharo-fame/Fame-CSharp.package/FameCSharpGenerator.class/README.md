FameCSharpGenerator new generateFor: MooseModel meta in: 'C:\Users\george\moose'.


{ 'C:\Users\george\moose\FILE' . 'C:\Users\george\moose\FAMIX' } 
do: [ :folder | 
	folder asFileReference entries do: [ :each | 
				('C:\Users\george\Source\Repos\roslyn2famix\RoslynMonoFamix\Model\' asFileReference / (each asFileReference path basename)) delete.
				each asFileReference copyTo: 					'C:\Users\george\Source\Repos\roslyn2famix\RoslynMonoFamix\Model\' asFileReference / (each asFileReference path basename)]. ].
