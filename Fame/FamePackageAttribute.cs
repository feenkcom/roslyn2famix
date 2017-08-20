namespace Fame
{
    using System;

    /// <summary>
    /// Indicates the FM3.Package of a fame-described element. If this annotation is
    /// not present, the declaring class and any enclosing classes are queried for
    /// FamePackage annotations. If none is found, the simple name of the enclosing
    /// java package is used. Thus, the FM3.Package name of a fame-described element
    /// is resolved in the following order:
    /// <ol>
    /// <li>FamePackage annotation of the element,
    /// <li>FamePackage annotation of declaring class (unless element is a class),
    /// <li>FamePackage annotation of any enclosing class,
    /// <li>FamePackage annotation of containing java package,
    /// <li>or else, last part of java package name.
    /// </ol>
    /// FM3 package names start with a letter, and may contain letters and numbers.
    /// It is recommended to use uppercase letters only.
    /// 
    /// @author Adrian Kuhn, 2008
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method | AttributeTargets.Field, Inherited = false)]
    public class FamePackageAttribute : Attribute
    {
        public FamePackageAttribute()
        {
        }

        public FamePackageAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; } = string.Empty;
    }
}