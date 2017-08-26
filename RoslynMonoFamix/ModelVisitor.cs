using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;

public class ModelVisitor : CSharpSyntaxWalker
{

    string className = String.Empty;

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        className = node.Identifier.ToString();
        base.VisitClassDeclaration(node);
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        string methodName = node.Identifier.ToString();
        Console.WriteLine(className + '.' + methodName);
        base.VisitMethodDeclaration(node);
    }

}