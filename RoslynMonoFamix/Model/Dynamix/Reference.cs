using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace Dynamix
{
  [FamePackage("Dynamix")]
  [FameDescription("Reference")]
  public class Reference : Dynamix.Entity
  {
    private List<Activation> activationsWithReceiver = new List<Activation>();
    
    [FameProperty(Name = "activationsWithReceiver",  Opposite = "receiver")]    
    public List <Activation> ActivationsWithReceiver
    {
      get { return activationsWithReceiver; }
      set { activationsWithReceiver = value; }
    }
    public void AddActivationsWithReceiver(Activation one)
    {
      activationsWithReceiver.Add(one);
    }
    
    private List<Activation> activationsWithReturn = new List<Activation>();
    
    [FameProperty(Name = "activationsWithReturn",  Opposite = "return")]    
    public List <Activation> ActivationsWithReturn
    {
      get { return activationsWithReturn; }
      set { activationsWithReturn = value; }
    }
    public void AddActivationsWithReturn(Activation one)
    {
      activationsWithReturn.Add(one);
    }
    
    private List<Activation> activationsWithArgument = new List<Activation>();
    
    [FameProperty(Name = "activationsWithArgument",  Opposite = "arguments")]    
    public List <Activation> ActivationsWithArgument
    {
      get { return activationsWithArgument; }
      set { activationsWithArgument = value; }
    }
    public void AddActivationsWithArgument(Activation one)
    {
      activationsWithArgument.Add(one);
    }
    
  }
}
