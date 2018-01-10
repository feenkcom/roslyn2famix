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
    private FAMIX.Type currentType;

    public ModelVisitor(SemanticModel semanticModel, InCSharpImporter importer)
    {
        this.semanticModel = semanticModel;
        this.importer = importer;
    }

    public override void VisitClassDeclaration(ClassDeclarationSyntax node)
    {
        var typeSymbol = semanticModel.GetDeclaredSymbol(node);
       
        FAMIX.Type type = type = importer.EnsureType(typeSymbol);
        var superType = typeSymbol.BaseType;

        //EnsureType also creates an instance and adds it to the model, we can't just overwrite the object here,
        //that is why the code below looks fishy
        if (superType != null && !(superType.ContainingNamespace.Name.Equals("System") && superType.Name.Equals("Object")))
        {
            FAMIX.Type baseType = importer.EnsureType(typeSymbol.BaseType);
            Inheritance inheritance = importer.CreateNewAssociation<Inheritance>("FAMIX.Inheritance");
            inheritance.subclass = type;
            inheritance.superclass = baseType;
            baseType.AddSubInheritance(inheritance);
            type.AddSuperInheritance(inheritance);
        }
       

        //type.name = node.Identifier.ToString();
        AddSuperInterfaces(typeSymbol, type);
        AddAnnotations(typeSymbol, type);
        AddParameterTypes(typeSymbol, type);
        currentType = type;
        importer.CreateSourceAnchor(type, node);
        type.isStub = false;
        if (type.container != null)
            type.container.isStub = false;
        base.VisitClassDeclaration(node);
        currentType = null;
    }

    private void AddParameterTypes(INamedTypeSymbol typeSymbol, FAMIX.Type type)
    {
        foreach (var typeParameter in typeSymbol.TypeParameters)
        {
            (type as ParameterizableClass).Parameters.Add(importer.EnsureType(typeParameter) as FAMIX.ParameterType);
        }
    }

    public override void VisitStructDeclaration(StructDeclarationSyntax node)
    {
        var typeSymbol = semanticModel.GetDeclaredSymbol(node);
        FAMIX.Type type = importer.EnsureType(typeSymbol);
    
        currentType = type;
        importer.CreateSourceAnchor(type, node);
        type.isStub = false;
        base.VisitStructDeclaration(node);
        currentType = null;
    }

    public override void VisitEnumDeclaration(EnumDeclarationSyntax node)
    {
        var typeSymbol = semanticModel.GetDeclaredSymbol(node);
        FAMIX.Type type = importer.EnsureType(typeSymbol);
        
        currentType = type;
        importer.CreateSourceAnchor(type, node);
        type.isStub = false;
        base.VisitEnumDeclaration(node);
        currentType = null;
    }

    public override void VisitEnumMemberDeclaration(EnumMemberDeclarationSyntax node)
    {
        string attributeName = node.Identifier.ToString();
        var symbol = semanticModel.GetDeclaredSymbol(node);
        FAMIX.EnumValue anEnumValue = importer.EnsureAttribute<FAMIX.EnumValue>(importer.Types.QualifiedName(currentType) + "." + attributeName, (ISymbol)symbol, "FAMIX.EnumValue");
        importer.CreateSourceAnchor(anEnumValue, node);
        if (currentType is FAMIX.Enum)
        {
            (currentType as FAMIX.Enum).AddValue(anEnumValue);
            anEnumValue.parentEnum = currentType as FAMIX.Enum;
            anEnumValue.isStub = false;
        }
      
    }

    //TODO add AnnotationInstanceAttribute link to AnnotationAttribute is not implemented
    //because in C# there are AnnotationAttributes that are initilized via constructors
    private void AddAnnotations(INamedTypeSymbol typeSymbol, FAMIX.NamedEntity type)
    {
        var attributes = typeSymbol.GetAttributes();
        foreach (var attr in attributes)
        {
            try
            {
                FAMIX.AnnotationInstance annotationInstance = importer.New<FAMIX.AnnotationInstance>();

                FAMIX.AnnotationType annonType = (FAMIX.AnnotationType)importer.EnsureType(attr.AttributeClass);
                annotationInstance.annotatedEntity = type;
                annotationInstance.annotationType = annonType;

                foreach (var constrArgument in attr.ConstructorArguments)
                {
                    AnnotationInstanceAttribute annotationInstanceAttribute = importer.New<FAMIX.AnnotationInstanceAttribute>();
                    annotationInstanceAttribute.value = constrArgument.Value.ToString();
                    annotationInstance.AddAttribute(annotationInstanceAttribute);
                }

                foreach (var namedArgument in attr.NamedArguments)
                {
                    AnnotationInstanceAttribute annotationInstanceAttribute = importer.New<FAMIX.AnnotationInstanceAttribute>();
                    annotationInstanceAttribute.value = namedArgument.Value.ToString();
                    annotationInstance.AddAttribute(annotationInstanceAttribute);
                }
            }
            catch (InvalidCastException c)
            {
                Console.WriteLine(c.Message);
            }
        }
    }

    private void AddSuperInterfaces(INamedTypeSymbol typeSymbol, FAMIX.Type type)
    {
        foreach (var inter in typeSymbol.Interfaces)
        {
            FAMIX.Class fInterface = (FAMIX.Class)importer.EnsureType(inter);
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
        FAMIX.Class type = (FAMIX.Class) importer.EnsureType(typeSymbol);
        type.isInterface = true;
        //type.name = node.Identifier.ToString();
        AddSuperInterfaces(typeSymbol, type);

        currentType = type;
        importer.CreateSourceAnchor(type, node);
        type.isStub = false;
        base.VisitInterfaceDeclaration(node);
        currentType = null;
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
        if (currentType != null)
        {
            var methodSymbol = semanticModel.GetDeclaredSymbol(node);
            
            String fullMethodName = FullMethodName(methodSymbol);
            Method aMethod = importer.EnsureMethod(fullMethodName, methodSymbol);
            aMethod.name = name;
            currentType.AddMethod(aMethod);
            aMethod.isConstructor = true;
            aMethod.parentType = currentType;
            currentMethod = aMethod;

            var returnType = importer.EnsureType(methodSymbol.ReturnType);
            currentMethod.declaredType = returnType;
            importer.CreateSourceAnchor(aMethod, node);
            currentMethod.isStub = false;
        }
        return currentMethod;
    }

    public override void VisitPropertyDeclaration(PropertyDeclarationSyntax node)
    {
        string propertyName = node.Identifier.ToString();
        AddProperty(node, propertyName);
        base.VisitPropertyDeclaration(node);
    }

    private void AddProperty(BasePropertyDeclarationSyntax node, String propertyName)
    {
        ISymbol symbol = semanticModel.GetDeclaredSymbol(node);
        FAMIX.Attribute propertyAttribute = null;
        
        if (currentType != null)
        {
            if (currentType is AnnotationType)
                propertyAttribute = importer.EnsureAttribute<FAMIX.AnnotationTypeAttribute>(importer.Types.QualifiedName(currentType) + "." + propertyName, symbol, "FAMIX.AnnotationTypeAttribute");
            else
                propertyAttribute = importer.EnsureAttribute<CSharp.CSharpProperty>(importer.Types.QualifiedName(currentType) + "." + propertyName, symbol, "CSharp.CSharpProperty");
            currentType.AddAttribute(propertyAttribute);
            propertyAttribute.parentType = currentType;
            propertyAttribute.isStub = false;
            importer.CreateSourceAnchor(propertyAttribute, node);
        }
    }

    public override void VisitEventDeclaration(EventDeclarationSyntax node)
    {
        string propertyName = node.Identifier.ToString();
        AddProperty(node, propertyName);
        base.VisitEventDeclaration(node);
    }

    public override void VisitEventFieldDeclaration(EventFieldDeclarationSyntax node)
    {
        AddField(node);
        base.VisitEventFieldDeclaration(node);
    }

    public override void VisitDelegateDeclaration(DelegateDeclarationSyntax node)
    {
        var typeSymbol = semanticModel.GetDeclaredSymbol(node);
        importer.EnsureType(typeSymbol);
        base.VisitDelegateDeclaration(node);
    }

    public override void VisitFieldDeclaration(FieldDeclarationSyntax node)
    {
        AddField(node);
        base.VisitFieldDeclaration(node);
    }

    private void AddField(BaseFieldDeclarationSyntax node)
    {
        foreach (var variable in node.Declaration.Variables)
        {
            string attributeName = variable.Identifier.ToString();
            var returnTypeSymbol = semanticModel.GetDeclaredSymbol(node.Declaration.Type);
           
            var symbol = semanticModel.GetDeclaredSymbol(variable);
            if (symbol is IFieldSymbol || symbol is IEventSymbol)
            {
                if (currentType != null)
                {
                    FAMIX.Attribute anAttribute = importer.EnsureAttribute<FAMIX.Attribute>(importer.Types.QualifiedName(currentType) + "." + attributeName, (ISymbol)symbol, "FAMIX.Attribute");
                
                    currentType.AddAttribute(anAttribute);
                    anAttribute.parentType = currentType;
                    importer.CreateSourceAnchor(anAttribute, node);
                    anAttribute.isStub = false;
                }
            }
        }
    }

    public override void VisitCatchDeclaration(CatchDeclarationSyntax node)
    {
        ISymbol typeSymbol = semanticModel.GetTypeInfo(node.Type).Type;
        var exceptionClass = (FAMIX.Class) importer.EnsureType(typeSymbol);
        FAMIX.CaughtException caughtException = importer.New<FAMIX.CaughtException>();
        caughtException.definingMethod = currentMethod;
        caughtException.exceptionClass = exceptionClass;
        base.VisitCatchDeclaration(node);
    }

    public override void VisitThrowStatement(ThrowStatementSyntax node)
    {
        if (node.Expression != null)
        {
            var symbolInfo = semanticModel.GetTypeInfo(node.Expression).Type;
        
            var exceptionClass = (FAMIX.Class)importer.EnsureType(symbolInfo);
            FAMIX.ThrownException thrownException = importer.New<FAMIX.ThrownException>();
            thrownException.definingMethod = currentMethod;
            thrownException.exceptionClass = exceptionClass;
        }
        base.VisitThrowStatement(node);
    }

    private T GetSymbol<T>(SyntaxNode node)
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
        try
        {
            if (currentMethod != null)
            {
                FAMIX.NamedEntity referencedEntity = FindReferencedEntity(node);
                if (referencedEntity is FAMIX.Method) AddMethodCall(node, currentMethod, referencedEntity as FAMIX.Method);
                if (referencedEntity is FAMIX.Attribute) AddAttributeAccess(node, currentMethod, referencedEntity as FAMIX.Attribute);
            }
        }
        catch (InvalidCastException e)
        {
            Console.WriteLine(e.Message);
        }
        base.VisitIdentifierName(node);
    }

    private void AddAttributeAccess(SyntaxNode node, Method clientMethod, FAMIX.Attribute attribute)
    {
        Access access = importer.CreateNewAssociation<Access>("FAMIX.Access");
        access.accessor = currentMethod;
        access.variable = attribute;
        clientMethod.AddAccesse(access);
        attribute.AddIncomingAccesse(access);
        importer.CreateSourceAnchor(access, node);
    }

    private void AddMethodCall(IdentifierNameSyntax node, Method clientMethod, Method referencedEntity)
    {
        Invocation invocation = importer.CreateNewAssociation<Invocation>("FAMIX.Invocation");
        invocation.sender = clientMethod;
        invocation.AddCandidate(referencedEntity);
        invocation.signature = node.Span.ToString();
        invocation.receiver = referencedEntity;
        clientMethod.AddOutgoingInvocation(invocation);
        referencedEntity.AddIncomingInvocation(invocation);
        importer.CreateSourceAnchor(invocation, node);
    }

    private NamedEntity FindReferencedEntity(IdentifierNameSyntax node)
    {
        var symbol = semanticModel.GetSymbolInfo(node).Symbol;
        if (symbol is IMethodSymbol)
            return importer.EnsureMethod(FullMethodName(symbol as IMethodSymbol), symbol as IMethodSymbol);
        if (symbol is IFieldSymbol)
            return importer.EnsureAttribute<FAMIX.Attribute>(importer.Types.QualifiedName(currentType) + "." + symbol.Name, symbol, "FAMIX.Attribute");
        if (symbol is IPropertySymbol)
            return importer.EnsureAttribute<CSharp.CSharpProperty>(importer.Types.QualifiedName(currentType) + "." + symbol.Name, symbol, "CSharp.CSharpProperty");
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

        return importer.Types.QualifiedName(currentType) + "." + method.Name + parameters;
    }

}