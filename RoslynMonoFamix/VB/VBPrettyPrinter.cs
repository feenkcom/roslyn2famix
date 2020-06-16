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

        public string PrettyText { get => prettyText; set => prettyText = value; }

        public override void DefaultVisit(SyntaxNode node)
        {
            PrettyText += node.Kind().GetText(); 
            base.DefaultVisit(node);
        }


    }
}
