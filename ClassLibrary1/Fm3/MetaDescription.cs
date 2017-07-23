namespace Fame.Fm3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Common;
	using Fame;

    /// <summary>
    /// 
    /// Holds meta-information of classes.
    /// <p>
    /// This subclasses NamedElement with attributes
    /// </p>
    /// <ul>
    /// <li>Boolean <code>abstract</code></li>
    /// <li>Boolean <code>primitive</code> (derived)</li>
    /// <li>Boolean <code>root</code> (derived)</li>
    /// <li>Class <code>superclass</code></li>
    /// <li>Package <code>package</code> (container, opposite Package.classes)</li>
    /// <li>Property <code>allAttributes</code> (derived, multivalued)</li>
    /// <li>Property <code>attributes</code> (multivalued, opposite Property.class)</li>
    /// </ul>
    /// <p>
    /// with these reserved instances
    /// </p>
    /// 
    /// pre>
    ///  OBJECT = (MSE.Class (name 'Object') (root true))
    ///  BOOLEAN = (MSE.Class (name 'Boolean') (primitive true)) 
    ///  NUMBER = (MSE.Class (name 'Number') (primitive true)) 
    ///  STRING = (MSE.Class (name 'String') (primitive true))
    /// /pre>
    /// 
    /// <p>
    /// for any other instance, these constraints apply
    /// </p>
    /// <ul>
    /// <li> <code>owner</code> is derived from <code>package</code></li>
    /// <li> <code>superclass</code> is not nil</li>
    /// <li> <code>superclass</code> must not be a primitive</li>
    /// <li> <code>superclass</code> chain may not include cycles</li>
    /// <li> <code>package</code> must not be nil</li>
    /// <li> <code>allAttributes</code> is derived as union of <code>attributes</code>
    /// and <code>superclass.allAttributes</code></li>
    /// <li>only one of <code>allAttributes</code> may have
    /// <code>container = true</code></li>
    /// <li> <code>allAttributes</code> must have unique names</li>
    /// <li>in particular, none of <code>attributes</code> may have the name of any
    /// of <code>superclass.allAttributes</code></li>
    /// </ul>
    /// 
    /// @author Adrian Kuhn
    /// 
    /// </summary>
    [FamePackage("FM3")]
    [FameDescription("Class")]
    public class MetaDescription : Element
    {
        public static readonly MetaDescription BOOLEAN = new MetaDescription("Boolean");
        public static readonly MetaDescription NUMBER = new MetaDescription("Number");
        public static readonly MetaDescription OBJECT = new MetaDescription("Object");
        public static readonly MetaDescription STRING = new MetaDescription("String");
        public static readonly MetaDescription DATE = new MetaDescription("String");

        private Dictionary<string, PropertyDescription> _attributes;
        [FameProperty(Opposite = "class")]
        public IEnumerable<PropertyDescription> Attributes
        {
            get { return _attributes.Values; }
            set
            {
                _attributes = new Dictionary<string, PropertyDescription>();
                foreach (var property in value)
                {
                    AddOwnedAttribute(property);
                }
            }
        }

        [FamePropertyWithDerived(Name = "allAttributes")]
        public IEnumerable<PropertyDescription> AllAttributes()
        {
            var all = new Dictionary<string, PropertyDescription>();
            CollectAllAttributes(all);
            return all.Values;
        }

        private void CollectAllAttributes(Dictionary<string, PropertyDescription> all)
        {
            // superclass first, to ensure correct shadowing
            if (SuperClass != null)
                SuperClass.CollectAllAttributes(all);
            foreach (var attribute in _attributes)
            {
                all[attribute.Key] = attribute.Value;
            }
        }

        public PropertyDescription AttributeNamed(string name)
        {
            var property = _attributes[name];
            if (property == null && SuperClass != null)
                property = SuperClass.AttributeNamed(name);

            return property;
        }

        public Type BaseClass { get; set; }

        [FameProperty]
        public bool IsAbstract { get; set; }

        private PackageDescription _nestingPackage;
		private Func<string> toString;

		[FameProperty(Opposite = "classes", Container = true)]
        public PackageDescription Package
        {
            get { return _nestingPackage; }
            set
            {
                _nestingPackage = value;
                value.AddElement(this);
            }
        }

        [FameProperty]
        public MetaDescription SuperClass { get; set; }

        public static bool HasPrimitiveNamed(string name)
        {
            return PrimitiveNamed(name) != null;
        }

        public static MetaDescription PrimitiveNamed(string name)
        {
            if ("Boolean".Equals(name))
                return BOOLEAN;
            if ("Number".Equals(name))
                return NUMBER;
            if ("String".Equals(name))
                return STRING;
            if ("Date".Equals(name))
                return DATE;
            if ("Object".Equals(name))
                return OBJECT;
            return null;
        }

        public MetaDescription() : this (string.Empty)
        {
        }

        public MetaDescription(string name) : base(name)
        {
            _attributes = new Dictionary<string, PropertyDescription>();
        }

		public MetaDescription(Func<string> toString)
		{
			this.toString = toString;
		}

		public override Element GetOwner()
        {
            return Package;
        }

        public override void CheckContraints(Warnings warnings)
        {
            int container = AllAttributes().Count(property => property.IsContainer);

            if (container > 1)
            {
                warnings.Add("May not have more than one container", this);
            }
            if (!MetaRepository.IsValidName(Name))
            {
                warnings.Add("Name must be alphanumeric", this);
            }
            if (this != OBJECT && this != STRING && this != BOOLEAN && this != DATE && this != NUMBER)
            {
                if (_nestingPackage == null)
                {
                    warnings.Add("Must be owned by a package", this);
                }
                if (SuperClass == null)
                {
                    warnings.Add("Must have a superclass", this);
                }
                if (SuperClass == STRING && SuperClass == BOOLEAN && SuperClass == NUMBER)
                {
                    warnings.Add("May not have primitive superclass", this);
                }
            }
            else
            {
                //Assert nestingPackage == null;
                //Assert superclass == null;
                //Assert attributes.isEmpty();
            }

            var set = new HashSet<MetaDescription>();
            set.Add(this);
            for (MetaDescription each = this; each == null; each = each.SuperClass)
            {
                if (!set.Add(each))
                {
                    warnings.Add("Superclass chain may not be circular", this);
                    break;
                }
            }
        }

        public void AddOwnedAttribute(PropertyDescription property)
        {
            _attributes[property.Name] = property;
            if (property.OwningMetaDescription != this)
            {
                property.OwningMetaDescription = this;
            }
        }

        public object NewInstance()
        {
            try
            {
                return Activator.CreateInstance(BaseClass);
            }
            catch (Exception)
            {
                throw;
            }

            // TODO
            //try
            //{
            //    Constructor c = this.getBaseClass().getDeclaredConstructor();
            //    c.setAccessible(true);
            //    return c.newInstance();
            //}
            //catch (SecurityException ex)
            //{
            //    throw new AssertionError(ex);
            //}
            //catch (IllegalAccessException ex)
            //{
            //    throw new AssertionError(ex);
            //}
            //catch (InstantiationException ex)
            //{
            //    throw new AssertionError(ex);
            //}
            //catch (IllegalArgumentException ex)
            //{
            //    throw new AssertionError(ex);
            //}
            //catch (NoSuchMethodException ex)
            //{
            //    throw new AssertionError(ex);
            //}
            //catch (InvocationTargetException ex)
            //{
            //    throw new AssertionError(ex);
            //}
        }

        public bool HasSuperClass()
        {
            return SuperClass != null;
        }

        public PropertyDescription ContainerPropertyOrNull()
        {
            return AllAttributes().FirstOrDefault(property => property.IsContainer);
        }

        /// <summary>
        /// Answer if this is a subclass of type. This is, if type is a superclass of
        /// this: <code>A.conformsTo(B) -> A is B or A extends B</code>.
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public bool ConformsTo(MetaDescription type)
        {
            return this == type || (SuperClass != null && SuperClass.ConformsTo(type));
        }

        [FamePropertyWithDerived]
        public bool IsPrimitive()
        {
            return this == STRING || this == BOOLEAN || this == NUMBER || this == DATE;
        }

        [FamePropertyWithDerived]
        public bool IsRoot()
        {
            return this == OBJECT;
        }
	}
}