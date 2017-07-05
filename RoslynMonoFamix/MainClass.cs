using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.MSBuild;
using System.Collections.Generic;

namespace RoslynMonoFamix
{
	class MainClass
	{
		static void Main(string[] args)
		{
			MainAsync(args).GetAwaiter().GetResult();
		}

		public static async Task MainAsync(string[] args)
		{
			const string code = @"
                public class MyClass {
                         int Method1() { return 0; }
                         void Method2()
                         {
                            int x = Method1();
                         }
                    }
                }";
			var tree = CSharpSyntaxTree.ParseText(code);
			var syntaxRoot = tree.GetRoot();

			var walker = new CustomWalker();
			walker.Visit(syntaxRoot);

			Console.WriteLine(typeof(object).GetTypeInfo().Assembly.Location);

			var Mscorlib = MetadataReference.CreateFromFile(typeof(object).GetTypeInfo().Assembly.Location);
			var compilation = CSharpCompilation.Create("MyCompilation",
				syntaxTrees: new[] { tree }, references: new[] { Mscorlib });

			var model = compilation.GetSemanticModel(tree);

			//Looking at the first method symbol
			var methodSyntax = tree.GetRoot().DescendantNodes().OfType<MethodDeclarationSyntax>().First();
			var methodSymbol = model.GetDeclaredSymbol(methodSyntax);

			Console.WriteLine(methodSymbol.ToString());
			Console.WriteLine(methodSymbol.GetAttributes());

			//Looking at the first method symbol
			var invocationSyntax = tree.GetRoot().DescendantNodes().OfType<InvocationExpressionSyntax>().First();
			var invokedSymbol = model.GetSymbolInfo(invocationSyntax).Symbol;

			Console.WriteLine(invocationSyntax.Parent.ToString());
			Console.WriteLine(invokedSymbol.ToString());
			Console.WriteLine(invokedSymbol.ContainingType);
			Console.WriteLine(invokedSymbol.GetAttributes());



			string solutionPath = "C:/Users/george/Source/Repos/roslyn2famix/RoslynMonoFamix.sln";

			var msWorkspace = MSBuildWorkspace.Create();
			var solution = await msWorkspace.OpenSolutionAsync(solutionPath);
			
			var documents = new List<Document>();
			foreach (var project in solution.Projects)
			{
				foreach (var document in project.Documents)
				{
					if (document.SupportsSyntaxTree)
					{
						var syntexTree = await document.GetSyntaxTreeAsync();

						var compilationAsync = await project.GetCompilationAsync();
						var semanticModel = compilationAsync.GetSemanticModel(syntexTree);
					
						
						if (syntexTree.GetRoot().DescendantNodes().OfType<InvocationExpressionSyntax>().Count() > 0)
						{
							var methoddeclaration = syntexTree.GetRoot().DescendantNodes().OfType<BaseMethodDeclarationSyntax>().First();
							if (methoddeclaration != null)
							{
								var invoked = semanticModel.GetDeclaredSymbol(methoddeclaration);
								if (invoked != null)
								{
									var callers = await Microsoft.CodeAnalysis.FindSymbols.SymbolFinder.FindCallersAsync(invoked, solution);
									Console.WriteLine(invoked.ToString());
									Console.WriteLine(callers.Count());
								}
							}
							
						}
						//Console.WriteLine(project.Name + "\t\t\t" + document.Name);
					}
				}
			}
			//List<MethodDeclarationSyntax> methods = documents.SelectMany(x => x.GetSyntaxRootAsync().Result.DescendantNodes().OfType<MethodDeclarationSyntax>()).ToList();

			Console.ReadKey();
		}
	}
}
