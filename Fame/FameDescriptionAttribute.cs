namespace Fame
{
    using System;

    /// <summary>
    /// Attaches FM3-related meta-information to C# classes.
    /// 
    /// @author Adrian Kuhn, 2007-2008
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class FameDescriptionAttribute : Attribute
    {
        public FameDescriptionAttribute()
        {
        }

        public FameDescriptionAttribute(string value)
        {
            Value = value;
        }

        public string Value { get; } = "*";
    }
}
