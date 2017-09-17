using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Fame;
using Model;
using Microsoft.CodeAnalysis;

public class ModelVisitor : CSharpSyntaxWalker
{

    private Repository metamodel;
    private SemanticModel semanticModel;

    public ModelVisitor(Repository metamodel, SemanticModel semanticModel)
    {
        this.metamodel = metamodel;
        this.semanticModel = semanticModel;
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        Class aClass = metamodel.NewInstance<Class>("FAMIX.Class");
        aClass.Name = node.Identifier.ToString();
        base.VisitClassDeclaration(node);
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        Method aMethod = metamodel.NewInstance<Method>("FAMIX.Method");
        aMethod.Name = node.Identifier.ToString();
        var methodSymbol = semanticModel.GetDeclaredSymbol(node);
        base.VisitMethodDeclaration(node);
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        foreach (var variable in node.Declaration.Variables)
        {
            Model.Attribute anAttribute = metamodel.NewInstance<Model.Attribute>("FAMIX.Attribute");
            anAttribute.Name = variable.Identifier.ToString();
        }
        base.VisitFieldDeclaration(node);
    }

    public IMethodSymbol GetMethodSymbol(SyntaxNode node)
    {
        var symbolInfo = semanticModel.GetSymbolInfo(node).Symbol;
        if (symbolInfo is IMethodSymbol methodSymbol)
            return methodSymbol;
        return null;
    }

    public override void VisitInvocationExpression(InvocationExpressionSyntax node)
    {
        var symbol = semanticModel.GetDeclaredSymbol(node);
        var expr = node.Expression;
        IMethodSymbol methodSymbol = null;
 
        if (expr is IdentifierNameSyntax)
        {
            IdentifierNameSyntax identifiername = expr as IdentifierNameSyntax; // identifiername is your method name
            methodSymbol = GetMethodSymbol(node);
        }

        if (expr is MemberAccessExpressionSyntax)
        {
            MemberAccessExpressionSyntax memberAccess = expr as MemberAccessExpressionSyntax;
            methodSymbol = GetMethodSymbol(node);
        }

        if (methodSymbol != null)
        {
            Console.WriteLine("\t\t\t Calling:" + methodSymbol.Name);
        }
        base.VisitInvocationExpression(node);
    }

}