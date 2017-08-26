using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Fame;
using Model;

public class ModelVisitor : CSharpSyntaxWalker
{

    public ModelVisitor(Repository metamodel)
    {
        this.metamodel = metamodel;
    }

    private Repository metamodel;

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        Class aClass = metamodel.NewInstance<Class>("FAMIX.Class");
        string className = node.Identifier.ToString();
        Console.WriteLine(className);
        base.VisitClassDeclaration(node);
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        Method aMethod = metamodel.NewInstance<Method>("FAMIX.Method");
        string methodName = node.Identifier.ToString();
        Console.WriteLine("\t" + methodName);
        base.VisitMethodDeclaration(node);
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        foreach (var variable in node.Declaration.Variables)
        {
            Model.Attribute anAttribute = metamodel.NewInstance<Model.Attribute>("FAMIX.Attribute");
            string attributeName = variable.Identifier.ToString();
            Console.WriteLine("\t" + attributeName);
        }
        base.VisitFieldDeclaration(node);
    }

}