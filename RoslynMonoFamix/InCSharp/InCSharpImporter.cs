using Fame;
using Microsoft.CodeAnalysis;
using FAMIX;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using CSharp;

namespace RoslynMonoFamix.InCSharp
{
    public class InCSharpImporter
    {
        private Repository repository;
        private string ignoreFolder;
       
        private Dictionary<string, System.Type> typeNameMap = new Dictionary<string, System.Type>()
            {
                { "Struct", typeof(CSharp.CSharpStruct) },
                { "Module", typeof(FAMIX.VBModule) },
                { "Class", typeof(FAMIX.Class) },
                { "Interface", typeof(FAMIX.Class) },
                { "Delegate", typeof(CSharp.Delegate) },
                { "TypeParameter", typeof(FAMIX.ParameterType)},
                { "Enum", typeof(FAMIX.Enum) },
            };

        public InCSharpImporter(Repository repository, string ignoreFolder)
        {
            this.repository = repository;
            this.Methods = new NamedEntityAccumulator<Method>();
            this.Types = new NamedEntityAccumulator<FAMIX.Type>();
            this.Namespaces = new NamedEntityAccumulator<Namespace>();
            this.Attributes = new NamedEntityAccumulator<FAMIX.StructuralEntity>();
            this.ignoreFolder = ignoreFolder;
        }
        public NamedEntityAccumulator<FAMIX.Namespace> Namespaces { get; set; }
        public NamedEntityAccumulator<FAMIX.Type> Types { get; set; }

        internal FAMIX.Type EnsureBinaryType(INamedTypeSymbol superType)
        {

            string fullName = FullTypeName(superType.OriginalDefinition);

            if (Types.has(fullName))
                return Types.Named(fullName);

            FAMIX.Type binaryType = EnsureType(superType.OriginalDefinition, typeof(FAMIX.Class));
            var members = superType.GetMembers();
            foreach (var member in members)
            {
                if (member is IFieldSymbol || member is IPropertySymbol)
                {
                    var attr = EnsureAttribute(member) as FAMIX.Attribute;
                    binaryType.AddAttribute(attr);
                    attr.parentType = binaryType;
                }
                if (member is IMethodSymbol)
                {
                    var methd = EnsureMethod(member as IMethodSymbol) as FAMIX.Method;
                    binaryType.AddMethod(methd);
                    methd.parentType = binaryType;
                }
            }

            if (superType.BaseType != null)
            {
                var superDuper = EnsureBinaryType(superType.BaseType.OriginalDefinition);
                LinkWithInheritance(binaryType, superDuper);
            }
               
            foreach (var inter in superType.AllInterfaces)
            {
                 var superDuper = EnsureBinaryType(inter.OriginalDefinition);
                 LinkWithInheritance(binaryType, superDuper);
            }

            return binaryType;
               
        }

        private void LinkWithInheritance(FAMIX.Type subClass, FAMIX.Type superClass)
        {
            Inheritance inheritance = CreateNewAssociation<Inheritance>(typeof(FAMIX.Inheritance).FullName);
            inheritance.subclass = subClass;
            inheritance.superclass = superClass;
            superClass.AddSubInheritance(inheritance);
            subClass.AddSuperInheritance(inheritance);
        }

        private Tuple<String,String> FullMethodName(ISymbol method)
        {
            var parameters = "";
            if (method is IMethodSymbol)
            {
                parameters += "(";
                foreach (var par in (method as IMethodSymbol).Parameters)
                    parameters += par.Type.Name + ",";
                if (parameters.LastIndexOf(",") > 0)
                    parameters = parameters.Substring(0, parameters.Length - 1);
                parameters += ")";
            }
            var fullClassName = "";
            if (method.ContainingType != null)
            {
                fullClassName = FullTypeName(method.ContainingType);
            }

            return Tuple.Create(fullClassName + "." + method.Name + parameters, method.Name + parameters);
        }

        public NamedEntityAccumulator<Method> Methods { get; set; }
        public NamedEntityAccumulator<FAMIX.StructuralEntity> Attributes { get; set; }

        public Method EnsureMethod(ISymbol aMethod)
        {
            var methodFullName = FullMethodName(aMethod);
            if (Methods.has(methodFullName.Item1))
                return Methods.Named(methodFullName.Item1);

            Method method = null;
            if (aMethod is IMethodSymbol && ((aMethod as IMethodSymbol).MethodKind == MethodKind.PropertyGet || (aMethod as IMethodSymbol).MethodKind == MethodKind.PropertySet))
                method = repository.New<CSharp.CSharpPropertyAccessor>(typeof(CSharp.CSharpPropertyAccessor).FullName);
            else 
                if (aMethod is IEventSymbol)
                    method = repository.New<CSharp.CSharpEvent>(typeof(CSharp.CSharpEvent).FullName);
                else
                    method = repository.New<Method>(typeof(FAMIX.Method).FullName);

            method.isStub = true;
            method.name = aMethod.Name;
            method.signature = methodFullName.Item2;
            Methods.Add(methodFullName.Item1, method);
            return method;
        }

        private String FullTypeName(ISymbol aType)
        {
            var symbolDisplayFormat = new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,  genericsOptions :SymbolDisplayGenericsOptions.IncludeTypeParameters);
            string fullyQualifiedName = aType.ToDisplayString(symbolDisplayFormat);
            if (aType is INamedTypeSymbol)
            {
                if ((aType as INamedTypeSymbol).IsGenericType && (aType as INamedTypeSymbol).IsDefinition)
                    fullyQualifiedName = "DefinitionOf" + fullyQualifiedName;
            }
            return fullyQualifiedName;
        }

        private String TypeName(ISymbol aType)
        {
            var symbolDisplayFormat = new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameOnly, genericsOptions: SymbolDisplayGenericsOptions.IncludeTypeParameters);
            string fullyQualifiedName = aType.ToDisplayString(symbolDisplayFormat);
            return fullyQualifiedName;
        }

        private FAMIX.Namespace EnsureNamespace(INamespaceSymbol ns)
        {
            if (Namespaces.has(ns.Name))
                return Namespaces.Named(ns.Name);
            FAMIX.Namespace newNs = repository.New<FAMIX.Namespace>(typeof(FAMIX.Namespace).FullName);
            newNs.name = ns.Name;
            newNs.isStub = true;
            Namespaces.Add(ns.Name, newNs);
            return newNs;
        }

        public FAMIX.Type EnsureType(ISymbol aType, System.Type defaultType)
        {

            string fullName = FullTypeName(aType);

            if (Types.has(fullName))
                return Types.Named(fullName);

            string typeKind = ResolveFAMIXTypeName(aType, defaultType).FullName;

            FAMIX.Type type = repository.New<FAMIX.Type>(typeKind);
            type.isStub = true;
            
            Types.Add(fullName, type);

            if (typeKind.Equals(typeof(FAMIX.ParameterizedType).FullName))
            {
                var parameterizedClass = EnsureType(aType.OriginalDefinition, defaultType);
                (type as FAMIX.ParameterizedType).parameterizableClass = parameterizedClass as FAMIX.ParameterizableClass;
            }

            type.name = TypeName(aType);
            if (aType.ContainingType != null)
            {
                var containingType = EnsureType(aType.ContainingType, defaultType);
                type.container = containingType;
            }
            else
            if (aType.ContainingNamespace != null)
            {
                var ns = EnsureNamespace(aType.ContainingNamespace);
                type.container = ns;
            }

            return type;
        }

        private System.Type ResolveFAMIXTypeName(ISymbol aType, System.Type defaultType)
        {
            System.Type result = defaultType;
            if (aType is ITypeSymbol) typeNameMap.TryGetValue(((ITypeSymbol)aType).TypeKind.ToString(), out result);
            if (aType is INamedTypeSymbol)
            {
                var superType = (aType as INamedTypeSymbol).BaseType;
                while (superType != null)
                {
                    if (superType.Name.Equals("Attribute") && superType.ContainingNamespace.Name.Equals("System"))
                        return typeof(FAMIX.AnnotationType);
                    if (superType.Name.Equals("Enum") && superType.ContainingNamespace.Name.Equals("System"))
                        return typeof(FAMIX.Enum);
                    superType = superType.BaseType;
                }
                   
                if ((aType as INamedTypeSymbol).IsGenericType)
                {
                    if ((aType as INamedTypeSymbol).IsDefinition)
                        result = typeof(FAMIX.ParameterizableClass);
                    else
                        result = typeof(FAMIX.ParameterizedType);
                }
            }
            if (aType is IArrayTypeSymbol)
                return ResolveFAMIXTypeName((aType as IArrayTypeSymbol).ElementType, defaultType);
            if (aType is IPointerTypeSymbol)
                return ResolveFAMIXTypeName((aType as IPointerTypeSymbol).PointedAtType, defaultType);
            if (result == null)
            {
                Console.WriteLine("Could not resolve type for  " + aType);
                if (aType.ContainingAssembly != null) Console.WriteLine("Containing Assembly " + aType.ContainingAssembly);
                result = defaultType;
            }
            return result;
        }

        public FAMIX.NamedEntity EnsureAttribute (ISymbol field) 
        {
            String attributeFullName = FullFieldName(field);
            if (Attributes.has(attributeFullName))
                return Attributes.Named(attributeFullName);

            string attributeKind = ResolveAttributeTypeName(field);

            var attribute = repository.New<FAMIX.NamedEntity>(attributeKind);
            attribute.isStub = true;
            attribute.name = field.Name;
            if (attribute is StructuralEntity)
                Attributes.Add(attributeFullName, attribute as StructuralEntity);
            else
                Methods.Add(attributeFullName, attribute as CSharpEvent);
            return attribute;
        }

        public FAMIX.Parameter CreateParameter(IParameterSymbol parameterSymbol)
        {
            var parameter = repository.New<FAMIX.Parameter>(typeof(FAMIX.Parameter).FullName);
            parameter.name = parameterSymbol.Name;
            parameter.declaredType = EnsureType(parameterSymbol.Type, typeof(FAMIX.Class));
            return parameter;
        }

        private string ResolveAttributeTypeName(ISymbol field)
        {
            if (field.ContainingType != null) {
                if (ResolveFAMIXTypeName(field.ContainingType, typeof(FAMIX.Class)).Equals(typeof(FAMIX.Enum)))
                    return typeof(FAMIX.EnumValue).FullName;
               if ( ResolveFAMIXTypeName(field.ContainingType, typeof(FAMIX.Class)).Equals(typeof(FAMIX.AnnotationType)))
                    return typeof(FAMIX.AnnotationTypeAttribute).FullName;
            }
            if (field is IEventSymbol)
                return typeof(CSharp.CSharpEvent).FullName;
            if (field is IPropertySymbol)
                return typeof(CSharp.CSharpProperty).FullName;
            return typeof(FAMIX.Attribute).FullName;
        }

        private String FullFieldName(ISymbol field)
        {
            var fullClassName = "";
            if (field.ContainingType != null)
            {
                fullClassName = FullTypeName(field.ContainingType);
            }
            return fullClassName + "." + field.Name;
        }

        public T CreateNewAssociation<T>(String typeName) => repository.New<T>(typeName);

        internal T New<T>()
        {
            return repository.New<T>(typeof(T).FullName);
        }

        public IEnumerable<T> AllElementsOfType<T>()
        {
            return repository.GetElements().OfType<T>();
        }

        public void CreateSourceAnchor(SourcedEntity sourcedEntity, SyntaxNode node)
        {
            
            var lineSpan = node.SyntaxTree.GetLineSpan(node.Span);
            var relativePath = node.SyntaxTree.FilePath.Substring(ignoreFolder.Length+1);
            FileAnchor fileAnchor = CreateNewFileAnchor(node, ref lineSpan);
            var loc = lineSpan.EndLinePosition.Line - lineSpan.StartLinePosition.Line;
            if (sourcedEntity is BehaviouralEntity) (sourcedEntity as BehaviouralEntity).numberOfLinesOfCode = loc;
            

            sourcedEntity.sourceAnchor = fileAnchor;
            repository.Add(fileAnchor);
        }

        public void CreateSourceAnchor(FAMIX.Type sourcedEntity, ClassDeclarationSyntax node)
        {
            var lineSpan = node.SyntaxTree.GetLineSpan(node.Span);
            FileAnchor fileAnchor = CreateNewFileAnchor(node, ref lineSpan);
            var loc = lineSpan.EndLinePosition.Line - lineSpan.StartLinePosition.Line;

            if (node.Modifiers.ToFullString().Contains("partial"))
            {
                if (sourcedEntity.sourceAnchor == null)
                {
                    sourcedEntity.sourceAnchor = new MultipleFileAnchor();
                    repository.Add(sourcedEntity.sourceAnchor);
                }
                (sourcedEntity.sourceAnchor as MultipleFileAnchor).AddAllFile(fileAnchor);
            }
            else
                sourcedEntity.sourceAnchor = fileAnchor;
            (sourcedEntity as FAMIX.Type).numberOfLinesOfCode += loc;

            repository.Add(fileAnchor);
        }

        private FileAnchor CreateNewFileAnchor(SyntaxNode node, ref FileLinePositionSpan lineSpan)
        {
            var relativePath = node.SyntaxTree.FilePath.Substring(ignoreFolder.Length + 1);
            FileAnchor fileAnchor = new FileAnchor
            {
                startLine = lineSpan.StartLinePosition.Line + 1,
                startColumn = lineSpan.StartLinePosition.Character,
                endLine = lineSpan.EndLinePosition.Line + 1,
                endColumn = lineSpan.EndLinePosition.Character + 1,
                fileName = relativePath
            };
            return fileAnchor;
        }
    }
}
