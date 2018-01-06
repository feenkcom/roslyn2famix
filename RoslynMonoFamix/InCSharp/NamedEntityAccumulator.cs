using Fame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynMonoFamix.InCSharp
{
    public class NamedEntityAccumulator<T>
    {

        private Dictionary<string, T> entities;
        private Dictionary<T, string> names;

        public NamedEntityAccumulator()
        {
            entities = new Dictionary<string, T>();
            names = new Dictionary<T, string>();
        }

        public List<T> get()
        {
            return entities.Values.ToList();
        }

        public T Add(String qualifiedName, T entity)
        {
            entities.Add(qualifiedName, entity);
            names.Add(entity, qualifiedName);
            return entity;
        }

        public T Named(String qualifiedName)
        {
            if (entities.ContainsKey(qualifiedName))
            {
                return entities[qualifiedName];
            }
            return default(T);
        }

        public string QualifiedName(T entity) => names[entity];

        public Boolean has(String qualifiedName)
        {
            return entities.ContainsKey(qualifiedName);
        }

        public int size()
        {
            return entities.Count;
        }

        public Boolean isEmpty()
        {
            return entities.Count == 0;
        }

    }
}
