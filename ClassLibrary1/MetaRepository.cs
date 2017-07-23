using Fame.Fm3;
using Fame.Internal;
using System;
using System.Collections.Generic;

namespace Fame
{
    public class MetaRepository : Repository
    {
		private Dictionary<String, Element> bindings = new Dictionary<string, Element>();

		private Dictionary<Type, MetaDescription> classes = new Dictionary<Type, MetaDescription>();

		public static bool IsValidName(string name)//TODO
		{
            throw new System.NotImplementedException();
        }

		public void With(Type type)
		{
			if (!classes.ContainsKey(type))
			{
				MetaDescriptionFactory factory = new MetaDescriptionFactory(type, this);
				MetaDescription instance = factory.CreateInstance();
				classes.Add(type, instance);
				factory.InitializeInstance();
				this.bindings.Add(instance.Fullname, instance);
			}
		}

		internal MetaDescription GetDescription(Type type)
		{
			classes.TryGetValue(type, out MetaDescription value);
			return value;
		}

		public Element Get(String fullName)
		{
			bindings.TryGetValue(fullName, out Element e);
			return e;
		}

		public PackageDescription InitializePackageNamed(String name)
		{
			if (!bindings.TryGetValue(name, out Element description))
			{
				description = new PackageDescription(name);
				bindings.Add(name, description);
			}
			return (PackageDescription)description;
		}
	}
}