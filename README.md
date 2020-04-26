# roslyn2famix

roslyn2famix is the C# equivalent of https://github.com/feenkcom/jdt2famix

It takes a C# `.sln` file as input and produces an `.mse` file that can be imported into (Glamorous Toolkit)[https://github.com/feenkcom/gtoolkit].

## Download, install and run
 Download the latest msi installer from [https://github.com/feenkcom/roslyn2famix/releases/latest](https://github.com/feenkcom/roslyn2famix/releases/latest).
 

 Install roslyn2famix and then run it like in the following usage example:

```
RoslynMonoFamix.exe .\github\CSharpSolution\CSharpSolution.sln CSharpSolution.mse
```

It is based on the new Roslyn compiler platform from Microsoft. So far, it has only been known to work on Windows even though it can be compiled using the Mac OS X version of Visual Studio.
