using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis;
using Fame;
using FAMIX;
using RoslynMonoFamix.InCSharp;
using CSharp;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;

namespace RoslynMonoFamix.VB
{
    public class VBASTVisitor : VisualBasicSyntaxWalker
    {
        private SemanticModel semanticModel;
        private InCSharpImporter importer;
        public VBASTVisitor(SemanticModel semanticModel, InCSharpImporter importer)
        {
            this.semanticModel = semanticModel;
            this.importer = importer;
        }

        public override void VisitModuleStatement(ModuleStatementSyntax node)
        {
            base.VisitModuleStatement(node);
            var typeSymbol = semanticModel.GetDeclaredSymbol(node);
            FAMIX.Type type = importer.EnsureType(typeSymbol, typeof(FAMIX.VBModule));
            // node.Identifier;
        }
    }
}
