using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("Moose")]
    [FameDescription("PropertyGroup")]
    public class PropertyGroup : Group
    {
        [FameProperty(Name = "property")]
        public String property { get; set; }

        [FameProperty(Name = "sizeRatio")]
        public Number sizeRatio { get; set; }

        [FameProperty(Name = "sizeOriginal")]
        public Number sizeOriginal { get; set; }

        [FameProperty(Name = "propertyTotal")]
        public Number propertyTotal { get; set; }

        [FameProperty(Name = "propertyRatio")]
        public Number propertyRatio { get; set; }

        [FameProperty(Name = "propertyTotalOriginal")]
        public Number propertyTotalOriginal { get; set; }







    }
}