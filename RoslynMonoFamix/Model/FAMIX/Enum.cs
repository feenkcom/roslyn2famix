using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("Enum")]
  public class Enum : FAMIX.Type
  {
    private List<EnumValue> values = new List<EnumValue>();
    
    [FameProperty(Name = "values",  Opposite = "parentEnum")]    
    public List <EnumValue> Values
    {
      get { return values; }
      set { values = value; }
    }
    public void AddValue(EnumValue one)
    {
      values.Add(one);
    }
    
  }
}
