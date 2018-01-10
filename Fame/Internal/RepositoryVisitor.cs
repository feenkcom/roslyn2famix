using Fame.Fm3;
using Fame.Parser;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Collections;

namespace Fame.Internal
{
    public class RepositoryVisitor
    {
        Repository repo;
        Dictionary<object, int> index;
        IParseClient visitor;

        public RepositoryVisitor(Repository repo, IParseClient visitor)
        {
            this.repo = repo;
            this.visitor = visitor;
            index = new Dictionary<object, int>();
            foreach (object element in repo.GetElements())
            {
                index.Add(element, index.Count + 1);
            }

        }

        internal void Run()
        {
            this.AcceptVisitor();
        }

        private void AcceptVisitor()
        {
            visitor.BeginDocument();
            IEnumerable<object> elements = RootElements(repo);
            elements = RemoveBuiltinMetaDescriptions(elements);
            foreach (object each in elements)
                this.AcceptElement(each);

            visitor.EndDocument();
        }

        private void AcceptElement(object each)
        {
            MetaDescription meta = repo.DescriptionOf(each);
            visitor.BeginElement(meta.Fullname);
            visitor.Serial(GetSerialNumber(meta, each));
            // XXX there can be more than one children property per element!
            PropertyDescription childrenProperty = ChildrenProperty(meta);
            if (childrenProperty == null || !childrenProperty.IsContainer)
            {
                foreach (PropertyDescription property in meta.AllAttributes().OrderBy(prop => prop.Name))
                {
                    if (property.IsDerived || property.IsContainer) continue;
                    ICollection<object> values = property.ReadAll(each);

                    if (property.Type == MetaDescription.BOOLEAN && (values.Count == 1) && !property.IsMultivalued)
                    {
                        var enumerator = values.GetEnumerator();
                        enumerator.MoveNext();
                        if (!(bool)enumerator.Current) continue;
                    }

                    if (values.Count > 0)
                    {
                        visitor.BeginAttribute(property.Name);
                        bool isPrimitive = property.Type.IsPrimitive();
                        bool isRoot = property.Type.IsRoot();
                        bool isComposite = (property == childrenProperty);
                        var enumerator = values.GetEnumerator();

                        while (enumerator.MoveNext())
                        {
                            object value = enumerator.Current;
                            if (value.GetType() == typeof(MetaDescription))
                            {
                                MetaDescription m = (MetaDescription)value;
                                if (m.IsPrimitive() || m.IsRoot())
                                {
                                    visitor.Reference(m.Name);
                                    continue;
                                }
                            }
                            if (isPrimitive || (isRoot &&
                                    (value.GetType() == typeof(String) ||
                                    value.GetType() == typeof(bool) ||
                                    Number.IsNumber(value))))
                            {
                                visitor.Primitive(value);
                            }
                            else
                            {
                                if (isComposite)
                                {
                                    this.AcceptElement(value);
                                }
                                else
                                {
                                    int serial = GetSerialNumber(property, value);

                                    visitor.Reference(serial);
                                }
                            }
                        }
                        visitor.EndAttribute(property.Name);
                    }
                }

                visitor.EndElement(meta.Fullname);
            }

        }

        private PropertyDescription ChildrenProperty(MetaDescription meta)
        {
            foreach (PropertyDescription attr in meta.Attributes)
            {
                if (attr.IsComposite()) return attr;
            }
            return null;
        }


        /** Returns the serial number of a given element
     * 
     * @param element an element of the current repository.
     * @throws AssertionError if the given object is not an element of the
     * current repository. This may happen, if a meta-described property refers
     * to objects that are not contained in the repository. Repositories must
     * be complete under transitive closure, that is, all objects reachable from
     * elements in a repository must be elements of the repository themselves. 
     * @return a unique serial number.
     */
        private int GetSerialNumber(Element description, Object element)
        {
            index.TryGetValue(element, out int serial);
            if (serial == 0)
                throw new UnknownElementError(description, element);
            return serial;
        }

        private IEnumerable<object> RemoveBuiltinMetaDescriptions(IEnumerable<object> elements)
        {
            HashSet<object> copy = new HashSet<object>(elements);
            copy.Remove(MetaDescription.OBJECT);
            copy.Remove(MetaDescription.STRING);
            copy.Remove(MetaDescription.NUMBER);
            copy.Remove(MetaDescription.BOOLEAN);
            copy.Remove(MetaDescription.DATE);
            return copy;
        }

        private IEnumerable<object> RootElements(Repository repo)
        {
            List<object> result = new List<object>();
            foreach (object each in repo.GetElements())
            {
                MetaDescription meta = repo.DescriptionOf(each);
                PropertyDescription containerProperty = meta.ContainerPropertyOrNull();
                if (containerProperty != null)
                {
                    Object container = containerProperty.Read(each);
                    if (container == null) result.Add(each);
                }
                else result.Add(each);
            };
            return result;
        }
    }
}
