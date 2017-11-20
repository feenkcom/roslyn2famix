using Fame;using System.Collections.Generic;namespace Model{



    [FamePackage("FAMIX")]
    [FameDescription("Enum")]
    public class Enum : Type
    {
        private List<EnumValue> values = new List<EnumValue>();        [FameProperty(Name = "values", Opposite = "parentEnum")]        public List EnumValues        {            get { return EnumValues; }            set { EnumValues = value; }        }        public void AddEnumValue(EnumValue one)        {            EnumValues.Add(one);        }






    }
}