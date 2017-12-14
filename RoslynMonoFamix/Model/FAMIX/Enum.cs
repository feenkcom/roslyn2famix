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
    private List<FAMIX.EnumValue> values = new List<FAMIX.EnumValue>();
    
    [FameProperty(Name = "values",  Opposite = "parentEnum")]    
    public List <FAMIX.EnumValue> Values
    {
      get { return values; }
      set { values = value; }
    }
    public void AddValue(FAMIX.EnumValue one)
    {
      values.Add(one);
    }
    
  }
}
