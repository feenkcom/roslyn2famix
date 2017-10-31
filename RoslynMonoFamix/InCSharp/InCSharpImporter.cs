using Fame;
using Microsoft.CodeAnalysis;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynMonoFamix.InCSharp
{
    public class InCSharpImporter
    {
        private Repository repository;

        public InCSharpImporter(Repository repository)
        {
            this.repository = repository;
            this.Methods = new NamedEntityAccumulator<Method>();
        }

        public NamedEntityAccumulator<Model.Type> Types { get; set; }
        public NamedEntityAccumulator<Method> Methods { get; set; }
        public NamedEntityAccumulator<Model.Attribute> Attributes { get; set; }

        public Method EnsureMethod(ISymbol aMethod)
        {
            if (Methods.has(aMethod.GetHashCode().ToString()))
                return Methods.Named(aMethod.GetHashCode().ToString());
            
            Method method = repository.NewInstance<Method>("FAMIX.Method");
            Methods.Add(aMethod.GetHashCode().ToString(), method);
            return method;
        }

    }
}
