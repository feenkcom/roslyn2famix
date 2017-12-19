using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using Fame;
using FAMIX;
using Microsoft.CodeAnalysis;
using RoslynMonoFamix.InCSharp;

public class ModelVisitor : CSharpSyntaxWalker
{
    private SemanticModel semanticModel;
    private InCSharpImporter importer;
    private Method currentMethod;
    private String currentClassKey;

    public ModelVisitor(SemanticModel semanticModel, InCSharpImporter importer)
    {
        this.semanticModel = semanticModel;
        this.importer = importer;
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        var typeSymbol = semanticModel.GetDeclaredSymbol(node);
        
        currentClassKey = FullTypeName(typeSymbol);
        FAMIX.Type type = null;
        var superType = typeSymbol.BaseType;

        //EnsureType also creates an instance and adds it to the model, we can't just overwrite the object here,
        //that is why the code below looks fishy
        if (superType != null && !(superType.ContainingNamespace.Name.Equals("System") && superType.Name.Equals("Object")))
        {
            if (superType.Name.Equals("Attribute") && superType.ContainingNamespace.Name.Equals("System"))
                type = importer.EnsureType(currentClassKey, typeSymbol, "FAMIX.AnnotationType");
            else
                type = importer.EnsureType(currentClassKey, typeSymbol, "FAMIX.Class");
            
            FAMIX.Type baseType = importer.EnsureType(FullTypeName(typeSymbol.BaseType), typeSymbol.BaseType, "FAMIX.Class");
            Inheritance inheritance = importer.CreateNewAssociation<Inheritance>("FAMIX.Inheritance");
            inheritance.subclass = type;
            inheritance.superclass = baseType;
            baseType.AddSubInheritance(inheritance);
            type.AddSuperInheritance(inheritance);
        }
        if (type == null)
            type = importer.EnsureType(currentClassKey, typeSymbol, "FAMIX.Class");

        type.name = node.Identifier.ToString();
        AddSuperInterfaces(typeSymbol, type);
        AddAnnotations(typeSymbol, type);

        base.VisitClassDeclaration(node);
        currentClassKey = null;
    }


    //TODO add AnnotationInstanceAttribute link to AnnotationAttribute is not implemented
    //because in C# there are AnnotationAttributes that are initilized via constructors
    private void AddAnnotations(INamedTypeSymbol typeSymbol, FAMIX.Type type)
    {
        var attributes = typeSymbol.GetAttributes();
        foreach (var attr in attributes)
        {
            FAMIX.AnnotationInstance annotationInstance = importer.NewInstance<FAMIX.AnnotationInstance>("FAMIX.AnnotationInstance");
            
            FAMIX.AnnotationType annonType = (FAMIX.AnnotationType) importer.EnsureType(FullTypeName(attr.AttributeClass), attr.AttributeClass, "FAMIX.AnnotationType");
            annotationInstance.annotatedEntity = type;
            annotationInstance.annotationType = annonType;

            foreach (var constrArgument in attr.ConstructorArguments)
            {
                AnnotationInstanceAttribute annotationInstanceAttribute = importer.NewInstance<FAMIX.AnnotationInstanceAttribute>("FAMIX.AnnotationInstanceAttribute");
                annotationInstanceAttribute.value = constrArgument.Value.ToString();
                annotationInstance.AddAttribute(annotationInstanceAttribute);
            }

            foreach (var namedArgument in attr.NamedArguments)
            {
                AnnotationInstanceAttribute annotationInstanceAttribute = importer.NewInstance<FAMIX.AnnotationInstanceAttribute>("FAMIX.AnnotationInstanceAttribute");
                annotationInstanceAttribute.value = namedArgument.Value.ToString();
                annotationInstance.AddAttribute(annotationInstanceAttribute);
            }
        }
    }

    private void AddSuperInterfaces(INamedTypeSymbol typeSymbol, FAMIX.Type type)
    {
        foreach (var inter in typeSymbol.Interfaces)
        {
            FAMIX.Class fInterface = (FAMIX.Class)importer.EnsureType(FullTypeName(inter), inter, "FAMIX.Class");
            fInterface.isInterface = true;
            Inheritance inheritance = importer.CreateNewAssociation<Inheritance>("FAMIX.Inheritance");
            inheritance.subclass = type;
            inheritance.superclass = fInterface;
            fInterface.AddSubInheritance(inheritance);
            type.AddSuperInheritance(inheritance);
        }
    }

    public override void VisitInterfaceDeclaration(InterfaceDeclarationSyntax node)
    {
        var typeSymbol = semanticModel.GetDeclaredSymbol(node);
        currentClassKey = FullTypeName(typeSymbol);
        FAMIX.Class type = (FAMIX.Class) importer.EnsureType(currentClassKey, typeSymbol, "FAMIX.Class");
        type.isInterface = true;
        type.name = node.Identifier.ToString();
        AddSuperInterfaces(typeSymbol, type);
        base.VisitInterfaceDeclaration(node);
        currentClassKey = null;
    }

    public override void VisitConstructorDeclaration(ConstructorDeclarationSyntax node)
    {
        string methodName = node.Identifier.ToString();
        AddMethod(node, methodName);

        if (currentMethod != null) currentMethod.isConstructor = true;

        base.VisitConstructorDeclaration(node);
        currentMethod = null;
    }

    public override void VisitMethodDeclaration(MethodDeclarationSyntax node)
    {
        string methodName = node.Identifier.ToString();
        AddMethod(node, methodName);
        base.VisitMethodDeclaration(node);
        currentMethod = null;
    }

    private Method AddMethod(BaseMethodDeclarationSyntax node, string name)
    {
        var currentClass = importer.Types.Named(currentClassKey);
        if (currentClass != null)
        {
            var methodSymbol = semanticModel.GetDeclaredSymbol(node);
            String fullMethodName = FullMethodName(methodSymbol);
            Method aMethod = importer.EnsureMethod(fullMethodName, methodSymbol);
            currentClass.AddMethod(aMethod);
            aMethod.isConstructor = true;
            aMethod.parentType = currentClass;
            currentMethod = aMethod;
        }
        return currentMethod;
    }

    public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        string propertyName = node.Identifier.ToString();
        ISymbol symbol = semanticModel.GetDeclaredSymbol(node);
        FAMIX.Attribute propertyAttribute = null; 
        var currentClass = importer.Types.Named(currentClassKey);
        if (currentClass != null)
        {
            if (currentClass is AnnotationType)
                propertyAttribute = importer.EnsureAttribute<FAMIX.AnnotationTypeAttribute>(currentClassKey + "." + propertyName, symbol, "FAMIX.AnnotationTypeAttribute");
            else
                propertyAttribute = importer.EnsureAttribute<CSharp.CSharpProperty>(currentClassKey + "." + propertyName, symbol, "CSharp.CSharpProperty");
            currentClass.AddAttribute(propertyAttribute);
            propertyAttribute.parentType = currentClass;
        }
        base.VisitPropertyDeclaration(node);
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        foreach (var variable in node.Declaration.Variables)
        {
            string attributeName = variable.Identifier.ToString();
            var symbol =  semanticModel.GetDeclaredSymbol(variable);
            if (symbol is IFieldSymbol)
            {
                FAMIX.Attribute anAttribute = importer.EnsureAttribute<FAMIX.Attribute>(currentClassKey + "." + attributeName, (IFieldSymbol) symbol, "FAMIX.Attribute");
                var currentClass = importer.Types.Named(currentClassKey);
                if (currentClass != null) {
                    currentClass.AddAttribute(anAttribute);
                    anAttribute.parentType = currentClass;
                }
            }
        }
        base.VisitFieldDeclaration(node);
    }

    public T GetSymbol<T>(SyntaxNode node)
    {
        var symbolInfo = semanticModel.GetSymbolInfo(node).Symbol;
        if (symbolInfo is T methodSymbol)
            return methodSymbol;
        return default(T);
    }

    /**
     * Visit an identifier, it can be anything, a method reference, a field, a local variable, etc.
     * We need to find out what it is and if it is located in a method and then make the appropriate connection.
     */
    public override void VisitIdentifierName(IdentifierNameSyntax node)
    {
        if (currentMethod != null)
        {
            FAMIX.NamedEntity referencedEntity = FindReferencedEntity(node);
            if (referencedEntity is FAMIX.Method) AddMethodCall(node, currentMethod, referencedEntity as FAMIX.Method);
            if (referencedEntity is FAMIX.Attribute) AddAttributeAccess(currentMethod, referencedEntity as FAMIX.Attribute);
        }
        base.VisitIdentifierName(node);
    }

    private void AddAttributeAccess(Method clientMethod, FAMIX.Attribute attribute)
    {
        Access access = importer.CreateNewAssociation<Access>("FAMIX.Access");
        access.accessor = currentMethod;
        access.variable = attribute;
        clientMethod.AddAccesse(access);
        attribute.AddIncomingAccesse(access);
    }

    private void AddMethodCall(IdentifierNameSyntax node, Method clientMethod, Method referencedEntity)
    {
        Invocation invocation = importer.CreateNewAssociation<Invocation>("FAMIX.Invocation");
        invocation.sender = clientMethod;
        invocation.AddCandidate(referencedEntity);
        invocation.signature = node.Span.ToString();
        clientMethod.AddOutgoingInvocation(invocation);
        referencedEntity.AddIncomingInvocation(invocation);
    }

    private NamedEntity FindReferencedEntity(IdentifierNameSyntax node)
    {
        var symbol = semanticModel.GetSymbolInfo(node).Symbol;
        if (symbol is IMethodSymbol)
            return importer.EnsureMethod(FullMethodName(symbol as IMethodSymbol), symbol as IMethodSymbol);
        if (symbol is IFieldSymbol)
            return importer.EnsureAttribute<FAMIX.Attribute>(currentClassKey + "." + symbol.Name, symbol, "FAMIX.Attribute");
        if (symbol is IPropertySymbol)
            return importer.EnsureAttribute<CSharp.CSharpProperty>(currentClassKey + "." + symbol.Name, symbol, "CSharp.CSharpProperty");
        return null;
    }

    private String FullMethodName(IMethodSymbol method)
    {
        var parameters = "(";
        foreach (var par in method.Parameters)
            parameters += par.Type.Name + ",";
        if (parameters.LastIndexOf(",") > 0)
            parameters = parameters.Substring(0, parameters.Length - 1);
        parameters += ")";

        return currentClassKey + "." + method.Name + parameters;
    }

    private String FullTypeName(INamedTypeSymbol aType)
    {
        String name = aType.Name;
        var ns = aType.ContainingNamespace;
        while (ns != null)
        {
            name = ns.Name + "." + name;
            ns = ns.ContainingNamespace;
        }
        return name;
    }

}