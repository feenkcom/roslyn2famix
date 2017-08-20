namespace Fame
{
    using Fm3;

    /// <summary>
    /// Indicates an nested element, used for name resolution.
    /// 
    /// @see Repository#fullname(Object)
    /// @author Adrian Kuhn, 2008
    /// </summary>
    public interface INested
    {
        /// <summary>
        /// Returns the owner of an element, or <code>null</code>. If a class
        /// implements both Owned and {@linkplain Named}, the instances returned by
        /// this method must implement {@linkplain Named} as well.
        /// 
        /// @return may return <code>null</code>
        /// </summary>
        Element GetOwner();
    }
}