using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace Dynamix
{
  [FamePackage("Dynamix")]
  [FameDescription("Event")]
  public class Event : Dynamix.Entity
  {
    private List<Event> children = new List<Event>();
    
    [FameProperty(Name = "children",  Opposite = "parent")]    
    public List <Event> Children
    {
      get { return children; }
      set { children = value; }
    }
    public void AddChildren(Event one)
    {
      children.Add(one);
    }
    
    [FameProperty(Name = "accumulatedLeavesDuration")]    
    public int accumulatedLeavesDuration { get; set; }
    
    [FameProperty(Name = "parent",  Opposite = "children")]    
    public Event parent { get; set; }
    
  }
}
