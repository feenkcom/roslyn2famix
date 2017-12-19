using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace RoslynMonoFamix
{
	public class CustomWalker : CSharpSyntaxWalker
	{
		static int Tabs = 0;
		public override void Visit(SyntaxNode node)
		{
			Tabs++;
			var indents = new String('\t', Tabs);
			//Console.WriteLine(indents + node.Kind());
			Console.WriteLine(indents + " " + node.Kind() + " " + node.GetReference().GetHashCode());
			base.Visit(node);
			Tabs--;
		}
	}
}
