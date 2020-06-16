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
        private Method currentMethod;
        private System.Collections.Stack currentTypeStack;

        public SemanticModel SemanticModel { get => semanticModel; set => semanticModel = value; }
        public InCSharpImporter Importer { get => importer; set => importer = value; }

        public VBASTVisitor(SemanticModel semanticModel, InCSharpImporter importer)
        {
            this.semanticModel = semanticModel;
            this.importer = importer;
            currentTypeStack = new System.Collections.Stack();
        }

        public override void VisitModuleStatement(ModuleStatementSyntax node)
        {
            base.VisitModuleStatement(node);
            var typeSymbol = semanticModel.GetDeclaredSymbol(node);
            FAMIX.Type type = importer.EnsureType(typeSymbol, typeof(FAMIX.VBModule));
        }

        public override void VisitClassStatement(ClassStatementSyntax node)
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

            AddSuperInterfaces(typeSymbol, type);
            //AddAnnotations(typeSymbol, type);
            //AddParameterTypes(typeSymbol, type);
            currentTypeStack.Push(type);
            importer.CreateSourceAnchor(type, node);
            type.isStub = false;
            if (type.container != null)
                type.container.isStub = false;
            //ComputeFanout(currentTypeStack.Peek() as FAMIX.Type);
           
            base.VisitClassStatement(node);
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

        public override void VisitInterfaceStatement(InterfaceStatementSyntax node)
        {
            var typeSymbol = semanticModel.GetDeclaredSymbol(node);
            FAMIX.Class type = (FAMIX.Class) importer.EnsureType(typeSymbol, typeof(FAMIX.Class));
            type.isInterface = true;
            AddSuperInterfaces(typeSymbol, type);
            currentTypeStack.Push(type);
            importer.CreateSourceAnchor(type, node);
            type.isStub = false;
            base.VisitInterfaceStatement(node);
        }

        public override void VisitInterfaceBlock(InterfaceBlockSyntax node)
        {
            base.VisitInterfaceBlock(node);
            currentTypeStack.Pop();
        }

        public override void VisitClassBlock(ClassBlockSyntax node)
        {
            base.VisitClassBlock(node);
            currentTypeStack.Pop();
        }

        public override void VisitMethodStatement(MethodStatementSyntax node)
        {
            //a MethodStatementSyntax is either a Function or a Sub
            string methodName = node.Identifier.ToString();
            AddMethod(node, methodName);
            base.VisitMethodStatement(node);
        }

        public override void VisitMethodBlock(MethodBlockSyntax node)
        {
            //AddMethod called from VisitMethodStatement sets currentMethod
            //we later use the currentMethod set above for calls and accesses
            base.VisitMethodBlock(node);
            //Set it back to null just to be on the safe side
            currentMethod = null;
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
            currentMethod = aMethod;
            return aMethod;
        }

        public override void VisitInvocationExpression(InvocationExpressionSyntax node)
        {
            try
            {
                if (currentMethod != null)
                {
                    FAMIX.NamedEntity referencedEntity = FindReferencedEntity(node.Expression);
                    if (referencedEntity is FAMIX.Method)
                        AddMethodCall(node, currentMethod, referencedEntity as FAMIX.Method);
                }
            }
            catch (InvalidCastException e)
            {
                Console.WriteLine(e.Message);
            }
            base.VisitInvocationExpression(node);
        }

        private void AddMethodCall(SyntaxNode node, Method clientMethod, Method referencedEntity)
        {
            Invocation invocation = importer.CreateNewAssociation<Invocation>("FAMIX.Invocation");
            invocation.sender = clientMethod;
            invocation.AddCandidate(referencedEntity);
            invocation.signature = node.Span.ToString();
            clientMethod.AddOutgoingInvocation(invocation);
            referencedEntity.AddIncomingInvocation(invocation);
            importer.CreateSourceAnchor(invocation, node);
        }

        private NamedEntity FindReferencedEntity(ExpressionSyntax node)
        {
            var symbol = semanticModel.GetSymbolInfo(node).Symbol;
            if (symbol is IMethodSymbol || symbol is IEventSymbol)
                return importer.EnsureMethod(symbol);
            if (symbol is IFieldSymbol)
                return importer.EnsureAttribute(symbol);
            if (symbol is IPropertySymbol)
                return importer.EnsureAttribute(symbol);
            return null;
        }
    }
}
