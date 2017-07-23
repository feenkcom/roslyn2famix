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
			instance = new MetaDescription(name.Value);
			return instance;
		}

		public void InitializeInstance()
		{
			InitializePackage();
			CreatePropertyFactories();
			CreatePropertyInstances();
			InitializeProperties();
		}

		private void InitializePackage()
		{
			var name = type.GetTypeInfo().GetCustomAttribute<FamePackageAttribute>();
			instance.Package = repository.InitializePackageNamed(name.Value);
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
