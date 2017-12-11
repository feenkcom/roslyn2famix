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
    [FameProperty(Name = "behaviour",  Opposite = "activations")]    
    public BehaviouralEntity behaviour { get; set; }
    
    [FameProperty(Name = "receiver",  Opposite = "activationsWithReceiver")]    
    public Reference receiver { get; set; }
    
    [FameProperty(Name = "return",  Opposite = "activationsWithReturn")]    
    public Reference _return { get; set; }
    
    private List<Reference> arguments = new List<Reference>();
    
    [FameProperty(Name = "arguments",  Opposite = "activationsWithArgument")]    
    public List <Reference> Arguments
    {
      get { return arguments; }
      set { arguments = value; }
    }
    public void AddArgument(Reference one)
    {
      arguments.Add(one);
    }
    
  }
}
