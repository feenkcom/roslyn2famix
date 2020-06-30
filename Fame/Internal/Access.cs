namespace Fame.Internal
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Reflection;

    public class Access
    {

        private Type elementType;
        private Type containerType;
        private PropertyInfo property;

        public Access(PropertyInfo p)
        {
            if (typeof(IEnumerable).GetTypeInfo().IsAssignableFrom(p.PropertyType.GetTypeInfo()) && p.PropertyType.GenericTypeArguments.Length > 0)
            {   //FIXME this is very brittle, do not do this at work kids
                elementType = p.PropertyType.GenericTypeArguments[0];
                containerType = p.PropertyType;
            }
            else elementType = p.PropertyType;
            property = p;
        }

        internal string GetName()
        {
            var name = property.GetCustomAttribute<FamePropertyAttribute>();
            if (name != null && name.Name != null) return name.Name;
            return property.Name;
        }

        internal Type GetElementType()
        {
            return elementType;
        }

        public object Read(object element)
        {
            return property.GetValue(element, null);
        }

        public void Write<T>(object element, ICollection<T> values)
        {
            throw new System.NotImplementedException();
        }

        public void Write<T>(object element, T value)
        {
            throw new System.NotImplementedException();
        }

        public bool IsMultivalued()
        {
            return containerType != null;
        }
    }
}