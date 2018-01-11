using Fame;
using Microsoft.CodeAnalysis;
using FAMIX;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RoslynMonoFamix.InCSharp
{
    public class InCSharpImporter
    {
        private Repository repository;
        private string ignoreFolder;
        //TODO map to type
        private Dictionary<string, string> typeNameMap = new Dictionary<string, string>()
            {
                { "Struct", "CSharp.CSharpStruct" },
                { "Class", "FAMIX.Class" },
                { "Interface", "FAMIX.Class" },
                { "Delegate", "CSharp.Delegate" },
                { "TypeParameter", "FAMIX.ParameterType"},
                { "Enum", "FAMIX.Enum" },
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
        public NamedEntityAccumulator<Method> Methods { get; set; }
        public NamedEntityAccumulator<FAMIX.StructuralEntity> Attributes { get; set; }

        public Method EnsureMethod(String methodFullName, IMethodSymbol aMethod)
        {
            if (Methods.has(methodFullName))
                return Methods.Named(methodFullName);
            
            Method method = repository.New<Method>("FAMIX.Method");
            method.isStub = true;
            method.name = aMethod.Name;
            Methods.Add(methodFullName, method);
            return method;
        }

        private String FullTypeName(ISymbol aType)
        {
            var symbolDisplayFormat = new SymbolDisplayFormat(typeQualificationStyle: SymbolDisplayTypeQualificationStyle.NameAndContainingTypesAndNamespaces,  genericsOptions :SymbolDisplayGenericsOptions.IncludeTypeParameters);
            string fullyQualifiedName = aType.ToDisplayString(symbolDisplayFormat);
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

        public FAMIX.Type EnsureType(ISymbol aType)
        {

            string fullName = FullTypeName(aType);

            if (Types.has(fullName))
                return Types.Named(fullName);

            string typeKind = ResolveFAMIXTypeName(aType);

            FAMIX.Type type = repository.New<FAMIX.Type>(typeKind);

            if (typeKind.Equals(typeof(FAMIX.ParameterizedType).FullName))
            {
                var parameterizedClass = EnsureType(aType.OriginalDefinition);
                (type as FAMIX.ParameterizedType).parameterizableClass = parameterizedClass as FAMIX.ParameterizableClass;
            }

            type.name = TypeName(aType);
            if (aType.ContainingType != null)
            {
                var containingType = EnsureType(aType.ContainingType);
                type.container = containingType;
            }
            else 
            if (aType.ContainingNamespace != null)
            {
                var ns = EnsureNamespace(aType.ContainingNamespace);
                type.container = ns;
            }
            type.isStub = true;
            Types.Add(fullName, type);
           
            return type;
        }

        private string ResolveFAMIXTypeName(ISymbol aType)
        {
            string result = "FAMIX.Class";
            if (aType is ITypeSymbol) typeNameMap.TryGetValue(((ITypeSymbol)aType).TypeKind.ToString(), out result);
            if (aType is INamedTypeSymbol)
            {
                
                var superType = (aType as INamedTypeSymbol).BaseType;
                if (superType != null && superType.Name.Equals("Attribute") && superType.ContainingNamespace.Name.Equals("System"))
                    result = "FAMIX.AnnotationType";
                if ((aType as INamedTypeSymbol).IsGenericType)
                {
                    if ((aType as INamedTypeSymbol).IsDefinition)
                        result = "FAMIX.ParameterizableClass";
                    else
                        result = "FAMIX.ParameterizedType";
                }
                    
            }
            if (result == null)
            {
                Console.WriteLine(" -------- " + ((ITypeSymbol)aType).TypeKind);
                result = "FAMIX.Class";
            }
            return result;
        }

        public T EnsureAttribute<T>  (String attributeFullName, ISymbol field, String attributeKind) where T : FAMIX.StructuralEntity
        {
            if (Attributes.has(attributeFullName))
                return (T)Attributes.Named(attributeFullName);
            T attribute = repository.New<T>(attributeKind);
            attribute.isStub = true;
            attribute.name = field.Name;
            Attributes.Add(attributeFullName, attribute);
            return attribute;
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
            FileAnchor fileAnchor = new FileAnchor
            {
                startLine = lineSpan.StartLinePosition.Line+1,
                startColumn = lineSpan.StartLinePosition.Character,
                endLine = lineSpan.EndLinePosition.Line+1,
                endColumn = lineSpan.EndLinePosition.Character+1,
                fileName = relativePath
            };
            sourcedEntity.sourceAnchor = fileAnchor;
            repository.Add(fileAnchor);
        }
    }
}
