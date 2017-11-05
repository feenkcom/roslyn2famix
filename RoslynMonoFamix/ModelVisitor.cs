using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Fame;
using Model;
using Microsoft.CodeAnalysis;
using RoslynMonoFamix.InCSharp;

public class ModelVisitor : CSharpSyntaxWalker
{
    private SemanticModel semanticModel;
    private InCSharpImporter importer;
    private Method currentMethod;

    public ModelVisitor (SemanticModel semanticModel, InCSharpImporter importer)
    {
        this.semanticModel = semanticModel;
        this.importer = importer;
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        var typeSymbol = semanticModel.GetDeclaredSymbol(node);
        Model.Type aType = importer.EnsureType(typeSymbol);
        base.VisitClassDeclaration(node);
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    { 
        string methodName = node.Identifier.ToString();
        Console.WriteLine("\t" + methodName);
        var methodSymbol = semanticModel.GetDeclaredSymbol(node);

        Method aMethod = importer.EnsureMethod(methodSymbol);
        currentMethod = aMethod;
        Console.WriteLine("\t\t ID from declaration:" + methodSymbol.GetHashCode());
        Console.WriteLine("\t\t" + methodSymbol.IsAbstract);
        base.VisitMethodDeclaration(node);
        currentMethod = null;
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        foreach (var variable in node.Declaration.Variables)
        {
            //Model.Attribute anAttribute = repository.NewInstance<Model.Attribute>("FAMIX.Attribute");
            //string attributeName = variable.Identifier.ToString();
            //Console.WriteLine("\t" + attributeName);
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
            Console.WriteLine("\t\t\t ID from usage:" + methodSymbol.GetHashCode());
        }
        if (expr is MemberAccessExpressionSyntax)
        {
             MemberAccessExpressionSyntax memberAccess = expr as MemberAccessExpressionSyntax;
             methodSymbol = GetMethodSymbol(node);
         }
 
         if (methodSymbol != null && currentMethod != null)
         {
             var calledMethod = importer.EnsureMethod(methodSymbol);
             // add the call to currentMethod here (once we have the model created)
             Console.WriteLine("\t\t\t Current method:" + currentMethod);
             Console.WriteLine("\t\t\t Calling:" + methodSymbol.Name);
             Console.WriteLine("\t\t\t ID from usage:" + methodSymbol.GetHashCode());
        }
        base.VisitInvocationExpression(node);
    }

}