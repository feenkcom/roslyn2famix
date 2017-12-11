using System;
using System.Collections.Generic;
using System.Text;
using Fame.Fm3;
using System.Reflection;
using Fame;
using System.Collections;

namespace Fame.Internal
{
	class MetaDescriptionFactory
	{
		private Type type;
		private MetaDescription instance;
		private MetaRepository repository;
		private List<PropertyFactory> childFactories;

		public MetaDescriptionFactory(Type type, MetaRepository repository)
		{
			this.type = type;
			this.repository = repository;
			childFactories = new List<PropertyFactory>();
		}

		public MetaDescription CreateInstance()
		{
			var name = type.GetTypeInfo().GetCustomAttribute<FameDescriptionAttribute>();
			if (name != null)
			{
				instance = new MetaDescription(name.Value)
				{
					BaseClass = type
				};
			}
			else
			{
				if (type.GetTypeInfo().FullName == "System.String")
					instance = MetaDescription.STRING;
				else if (type.GetTypeInfo().FullName == "System.Boolean")
					instance = MetaDescription.BOOLEAN;
				else
					instance = new MetaDescription(type.GetTypeInfo().Name)
					{
						BaseClass = type
					};
			}
			
			return instance;
		}

		public void InitializeInstance()
		{
			InitializePackage();
			CreatePropertyFactories();
			CreatePropertyInstances();
            InitializeSuperclass();
			InitializeProperties();
		}

        private void InitializeSuperclass()
        {
            if (type.BaseType != null)
            {
                repository.With(type.BaseType);
                MetaDescription superclass = repository.GetDescription(type.BaseType);
                if (superclass != null)
                    instance.SuperClass = superclass;
            }
        }

        private void InitializePackage()
		{
			var name = type.GetTypeInfo().GetCustomAttribute<FamePackageAttribute>();
			var packageName = type.GetTypeInfo().Namespace;
			if (name != null)
				packageName = name.Value;
			instance.Package = repository.InitializePackageNamed(packageName);
			instance.Package.AddElement(instance);
		}

		private void CreatePropertyFactories()
		{
			var declaredProperties = type.GetTypeInfo().DeclaredProperties;
			foreach (PropertyInfo method in declaredProperties)
			{
				PropertyFactory propertyFactory = new PropertyFactory(new Access(method), repository);
				childFactories.Add(propertyFactory);
			}
		}

		private void CreatePropertyInstances()
		{
			foreach (PropertyFactory factory in childFactories)
			{
				PropertyDescription property = factory.CreateInstance();
				instance.AddOwnedAttribute(property);
				property.SetOwningMetaDescription(instance);
			}
		}

		private void InitializeProperties()
		{
			foreach (PropertyFactory factory in childFactories) factory.InitializeInstance();
		}

	}
}
