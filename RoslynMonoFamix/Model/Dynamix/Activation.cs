using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace Dynamix
{
  [FamePackage("Dynamix")]
  [FameDescription("Activation")]
  public class Activation : Dynamix.Event
  {
    [FameProperty(Name = "return",  Opposite = "activationsWithReturn")]    
    public Dynamix.Reference _return { get; set; }
    
    [FameProperty(Name = "behaviour",  Opposite = "activations")]    
    public FAMIX.BehaviouralEntity behaviour { get; set; }
    
    private List<Dynamix.Reference> arguments = new List<Dynamix.Reference>();
    
    [FameProperty(Name = "arguments",  Opposite = "activationsWithArgument")]    
    public List <Dynamix.Reference> Arguments
    {
      get { return arguments; }
      set { arguments = value; }
    }
    public void AddArgument(Dynamix.Reference one)
    {
      arguments.Add(one);
    }
    
    [FameProperty(Name = "receiver",  Opposite = "activationsWithReceiver")]    
    public Dynamix.Reference receiver { get; set; }
    
  }
}
