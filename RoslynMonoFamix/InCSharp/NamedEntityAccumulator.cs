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

        public NamedEntityAccumulator()
        {
            entities = new Dictionary<string, T>();
        }

        public List<T> get()
        {
            return entities.Values.ToList();
        }

        public T Add(String qualifiedName, T entity)
        {
            try
            {
                entities.Add(qualifiedName, entity);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e);
            } 
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
