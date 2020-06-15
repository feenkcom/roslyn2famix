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

        public SemanticModel SemanticModel { get => semanticModel; set => semanticModel = value; }
        public InCSharpImporter Importer { get => importer; set => importer = value; }

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
        }

        public override void VisitMethodStatement(MethodStatementSyntax node)
        {
            //a MethodStatementSyntax is either a Function or a Sub
            base.VisitMethodStatement(node);
            string methodName = node.Identifier.ToString();
            AddMethod(node, methodName);
        }

        private Method AddMethod(MethodStatementSyntax node, string name)
        {
            var methodSymbol = semanticModel.GetDeclaredSymbol(node);
            Method aMethod = importer.EnsureMethod(methodSymbol);
            node.Modifiers.ToList<SyntaxToken>().ForEach(token => aMethod.Modifiers.Add(token.Text));
            aMethod.name = name;
            aMethod.parentType = importer.EnsureType(methodSymbol.ContainingType, typeof(FAMIX.Class));
            aMethod.parentType.AddMethod(aMethod);
                         
            var returnType = importer.EnsureType(methodSymbol.ReturnType, typeof(FAMIX.Class));
            aMethod.declaredType = returnType;
            importer.CreateSourceAnchor(aMethod, node);
            aMethod.isStub = false;
            return aMethod;
        }
    }
}
