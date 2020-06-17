using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis;

namespace RoslynMonoFamix.VB
{
    public class VBPrettyPrinter : VisualBasicSyntaxWalker
    {
        private String prettyText = "";
        private int indentation = 0;

        public string PrettyText { get => prettyText; set => prettyText = value; }

        public override void Visit(SyntaxNode node)
        {
            var indent = "";
            for (var i = 0; i <= indentation; i++)
            {
                indent += " ";
            }
            PrettyText += indent +  node.Kind().ToString() + " " + node.Span.ToString() + " " + node.GetFirstToken().ToString() + "\n"; 

            if (node.ChildNodes().Count() > 0)
            {
                indentation++;
            }
            base.DefaultVisit(node);
            if (node.ChildNodes().Count() > 0)
            {
                indentation--;
            }
        }
    }
}
