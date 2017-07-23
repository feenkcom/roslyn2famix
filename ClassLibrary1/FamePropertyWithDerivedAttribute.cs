namespace Fame
{
    using System;

    /// <summary>
    /// Attaches FM3-related meta-information to class members (ie fields or
    /// methods).
    /// 
    /// @author akuhn
    /// </summary>
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Field)]
    public class FamePropertyWithDerivedAttribute : Attribute
    {
        public bool Container { get; } = false;
        public bool Derived { get; } = true;
        public string Name { get; set; } = "*";
        public string Opposite { get; } = string.Empty;
        public Type Type { get; } = typeof(object);
    }
}