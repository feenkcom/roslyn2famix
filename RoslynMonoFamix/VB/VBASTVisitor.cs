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
using Type = FAMIX.Type;

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

        public override void VisitClassStatement(ClassStatementSyntax node)
        {
            base.VisitClassStatement(node);
            string className = node.Identifier.ToString();
            AddClass(node, className);
        }

        private Type AddClass(ClassStatementSyntax node, string name)
        {
            var typeSymbol = semanticModel.GetDeclaredSymbol(node);

            FAMIX.Type type = type = importer.EnsureType(typeSymbol, typeof(FAMIX.Class));
            node.Modifiers.ToList<SyntaxToken>().ForEach(token => type.Modifiers.Add(token.Text));
            var superType = typeSymbol.BaseType;

            if (superType != null)
            {
                FAMIX.Type baseType = null;
                if (superType.DeclaringSyntaxReferences.Length == 0)
                    baseType = importer.EnsureBinaryType(superType);
                else
                    baseType = importer.EnsureType(typeSymbol.BaseType, typeof(FAMIX.Class));
                Inheritance inheritance = importer.CreateNewAssociation<Inheritance>(typeof(FAMIX.Inheritance).FullName);
                inheritance.subclass = type;
                inheritance.superclass = baseType;
                baseType.AddSubInheritance(inheritance);
                type.AddSuperInheritance(inheritance);
            }

            type.name = node.Identifier.ToString();
            AddSuperInterfaces(typeSymbol, type);
            importer.CreateSourceAnchor(type, node);
            type.isStub = false;
            if (type.container != null)
                type.container.isStub = false;
            return type;
        }
        private void AddSuperInterfaces(INamedTypeSymbol typeSymbol, FAMIX.Type type)
        {
            foreach (var inter in typeSymbol.Interfaces)
            {
                FAMIX.Type fInterface = (FAMIX.Type)importer.EnsureType(inter, typeof(FAMIX.Class));
                if (fInterface is FAMIX.Class) (fInterface as FAMIX.Class).isInterface = true;
                Inheritance inheritance = importer.CreateNewAssociation<Inheritance>("FAMIX.Inheritance");
                inheritance.subclass = type;
                inheritance.superclass = fInterface;
                fInterface.AddSubInheritance(inheritance);
                type.AddSuperInheritance(inheritance);
            }
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

            methodSymbol.Parameters.ToList<IParameterSymbol>().ForEach(parameter => aMethod.Parameters.Add(importer.CreateParameter(parameter)));

            var returnType = importer.EnsureType(methodSymbol.ReturnType, typeof(FAMIX.Class));
            aMethod.declaredType = returnType;
            importer.CreateSourceAnchor(aMethod, node);
            aMethod.isStub = false;
            return aMethod;
        }

    }
}
