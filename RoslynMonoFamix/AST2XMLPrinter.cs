using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Fame;
using FAMIX;
using Microsoft.CodeAnalysis;

namespace RoslynMonoFamix
{
    public class AST2XMLPrinter : CSharpSyntaxWalker
    {
        private System.IO.StreamWriter file = null;
        private int indentation = 0;

        public AST2XMLPrinter (System.IO.StreamWriter file)
        {
            this.file = file;
        }

        public override void Visit(SyntaxNode node)
        {
            PrintNode(node);
            indentation++;
            base.Visit(node);
            indentation--;
        }

        private void PrintNode(SyntaxNode node)
        {
           for(int i=0; i<indentation; i++) file.Write(" ");
           file.WriteLine(node.GetType().FullName + " " + node.Span.ToString());
        }
    }
}
