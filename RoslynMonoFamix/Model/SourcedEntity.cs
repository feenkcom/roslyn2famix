using Fame;



    [FamePackage("FAMIX")]
    [FameDescription("SourcedEntity")]
    public class SourcedEntity : Entity
    {
        [FameProperty(Name = "declaredSourceLanguage") Opposite = "sourcedEntities"]
        public SourceLanguage declaredSourceLanguage { get; set; }









    }
}