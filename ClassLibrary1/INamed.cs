namespace Fame
{
    /// <summary>
    /// Indicates a named elements, used for name resolution.
    /// 
    /// @see Repository#fullname(Object)
    /// @author Adrian Kuhn, 2008
    /// </summary>
    public interface INamed
    {
        /// <summary>
        /// Returns the name of an element.
        /// 
        /// @return must not return <code>null</code>.
        /// </summary>
        string Name { get; }
    }
}