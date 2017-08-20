namespace Fame
{
    using System;

    /// <summary>
    /// Attaches FM3-related meta-information to class members (ie fields or
    /// methods).
    /// 
    /// @author akuhn
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field, Inherited = false)]
    public class FamePropertyAttribute : Attribute
    {
        public bool Container { get; set; } = false;
        public bool Derived { get; } = false;
        public string Name { get; set; } = "*";
        public string Opposite { get; set; } = string.Empty;
        public Type Type { get; } = typeof(object);
    }
}