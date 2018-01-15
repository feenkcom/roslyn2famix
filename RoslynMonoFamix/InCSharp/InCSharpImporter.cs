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
        private Dictionary<string, System.Type> typeNameMap = new Dictionary<string, System.Type>()
            {
                { "Struct", typeof(CSharp.CSharpStruct) },
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

            string typeKind = ResolveFAMIXTypeName(aType).FullName;

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

        private System.Type ResolveFAMIXTypeName(ISymbol aType)
        {
            System.Type result = typeof(FAMIX.Class);
            if (aType is ITypeSymbol) typeNameMap.TryGetValue(((ITypeSymbol)aType).TypeKind.ToString(), out result);
            if (aType is INamedTypeSymbol)
            {
                
                var superType = (aType as INamedTypeSymbol).BaseType;
                if (superType != null && superType.Name.Equals("Attribute") && superType.ContainingNamespace.Name.Equals("System"))
                    result = typeof(FAMIX.AnnotationType);
                if ((aType as INamedTypeSymbol).IsGenericType)
                {
                    if ((aType as INamedTypeSymbol).IsDefinition)
                        result = typeof(FAMIX.ParameterizableClass);
                    else
                        result = typeof(FAMIX.ParameterizedType);
                }
                    
            }
            if (result == null)
            {
                Console.WriteLine(" -------- " + ((ITypeSymbol)aType).TypeKind);
                result = typeof(FAMIX.Class);
            }
            return result;
        }

        public FAMIX.StructuralEntity EnsureAttribute  ( ISymbol field) 
        {
            String attributeFullName = FullFieldName(field);
            if (Attributes.has(attributeFullName))
                return Attributes.Named(attributeFullName);

            string attributeKind = ResolveAttritbuteTypeName(field);

            var attribute = repository.New<FAMIX.StructuralEntity>(attributeKind);
            attribute.isStub = true;
            attribute.name = field.Name;
            Attributes.Add(attributeFullName, attribute);
            return attribute;
        }

        private string ResolveAttritbuteTypeName(ISymbol field)
        {
            if (field.ContainingType != null) {
                if (ResolveFAMIXTypeName(field.ContainingType).Equals(typeof(FAMIX.Enum)))
                    return typeof(FAMIX.EnumValue).FullName;
               if ( ResolveFAMIXTypeName(field.ContainingType).Equals(typeof(FAMIX.AnnotationType)))
                    return typeof(FAMIX.AnnotationTypeAttribute).FullName;
            }
            if (field is IPropertySymbol)
                return typeof(CSharp.CSharpProperty).FullName;
            return typeof(FAMIX.Attribute).FullName;
        }

        private String FullFieldName(ISymbol field)
        {
            var fullClassName = "";
            if (field.ContainingType != null)
            {
                var methodContainer = EnsureType(field.ContainingType);
                fullClassName = Types.QualifiedName(methodContainer);
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
