using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Enum")]
  public class Enum : Type
  {
    private List<EnumValue> values = new List<EnumValue>();
    
    [FameProperty(Name = "values",  Opposite = "parentEnum")]    
    public List Values
    {
      get { return Values; }
      set { Values = value; }
    }
    public void AddEnumValue(EnumValue one)
    {
      Values.Add(one);
    }
    
  }
}
