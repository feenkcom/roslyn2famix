using Fame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoslynMonoFamix.InCSharp
{
    class NamedEntityAccumulator<T>
    {
        private Repository repository;

        private Dictionary<String, T> entities;

        public NamedEntityAccumulator(Repository repository)
        {
            this.repository = repository;
            entities = new Dictionary<String, T>();
        }

        //public List<T> get()
        //{
        //    return entities
        //        .entrySet()
        //        .stream()
        //        .map(p->p.getValue())
        //        .collect(Collectors.toList());
        //}

        //public Stream<T> stream()
        //{
        //    return entities
        //            .entrySet()
        //            .stream()
        //            .map(p->p.getValue());
        //}

        public T add(String qualifiedName, T entity)
        {
            entities.Add(qualifiedName, entity);
            repository.Add(entity);
            return entity;
        }
        public T named(String qualifiedName)
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
