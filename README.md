# roslyn2famix

Roslyn to Famix is a C# model extrator written in C#.

It takes a C# .sln file as input and produces a MSE file to be imported in Moose.

Example:

RoslynMonoFamix.exe .\github\CSharpSolution\CSharpSolution.sln CSharpSolution.mse


```
Iceberg enableMetacelloIntegration: true.
Metacello new
   baseline: 'GToolkitConstrainer';
   repository: 'github://feenkcom/gtoolkit-constrainer';
    load.
```
