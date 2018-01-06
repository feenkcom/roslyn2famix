using Fame;
using Microsoft.CodeAnalysis;
using FAMIX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CSharp;

namespace RoslynMonoFamix.InCSharp
{
    public class InCSharpImporter
    {
        private Repository repository;
        private Dictionary<string, string> typeNameMap = new Dictionary<string, string>()
            {
                { "Struct", "CSharp.CSharpStruct" },
                { "Class", "FAMIX.Class" },
                { "Interface", "FAMIX.Class" },
                { "Delegate", "CSharp.Delegate" },
                { "TypeParameter", "FAMIX.ParameterType"},
                { "Enum", "FAMIX.Enum" },
            };

        public InCSharpImporter(Repository repository)
        {
            this.repository = repository;
            this.Methods = new NamedEntityAccumulator<Method>();
            this.Types = new NamedEntityAccumulator<FAMIX.Type>();
            this.Attributes = new NamedEntityAccumulator<FAMIX.StructuralEntity>();
        }

        public NamedEntityAccumulator<FAMIX.Type> Types { get; set; }
        public NamedEntityAccumulator<Method> Methods { get; set; }
        public NamedEntityAccumulator<FAMIX.StructuralEntity> Attributes { get; set; }

        public Method EnsureMethod(String methodFullName, IMethodSymbol aMethod)
        {
            if (Methods.has(methodFullName))
                return Methods.Named(methodFullName);
            
            Method method = repository.NewInstance<Method>("FAMIX.Method");
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

        public FAMIX.Type EnsureType(ISymbol aType)
        {

            string fullName = FullTypeName(aType);

            if (Types.has(fullName))
                return Types.Named(fullName);

            string typeKind = ResolveFAMIXTypeName(aType);

            FAMIX.Type type = repository.NewInstance<FAMIX.Type>(typeKind);

            if (typeKind.Equals("FAMIX.ParameterizedType"))
            {
                var parameterizedClass = EnsureType(aType.OriginalDefinition);
                (type as FAMIX.ParameterizedType).parameterizableClass = parameterizedClass as FAMIX.ParameterizableClass;
            }

            type.name = TypeName(aType);
            
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
            return result;
        }

        public T EnsureAttribute<T>  (String attributeFullName, ISymbol field, String attributeKind) where T : FAMIX.StructuralEntity
        {
            if (Attributes.has(attributeFullName))
                return (T)Attributes.Named(attributeFullName);
            T attribute = repository.NewInstance<T>(attributeKind);

            attribute.name = field.Name;
            Attributes.Add(attributeFullName, attribute);
            return attribute;
        }

        public T CreateNewAssociation<T>(String typeName) => repository.NewInstance<T>(typeName);

        internal T NewInstance<T>(string typeName)
        {
            return repository.NewInstance<T>(typeName);
        }

        public IEnumerable<T> AllElementsOfType<T>()
        {
            return repository.GetElements().OfType<T>();
        } 
    }
}
