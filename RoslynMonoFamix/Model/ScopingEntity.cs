using Fame;



    [FamePackage("FAMIX")]
    [FameDescription("ScopingEntity")]
    public class ScopingEntity : ContainerEntity
    {
        [FameProperty(Name = "parentScope") Opposite = "childScopes"]
        public ScopingEntity parentScope { get; set; }









    }
}