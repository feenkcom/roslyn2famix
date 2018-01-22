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
    private List<Dynamix.Activation> activationsWithArgument = new List<Dynamix.Activation>();
    
    [FameProperty(Name = "activationsWithArgument",  Opposite = "arguments")]    
    public List <Dynamix.Activation> ActivationsWithArgument
    {
      get { return activationsWithArgument; }
      set { activationsWithArgument = value; }
    }
    public void AddActivationsWithArgument(Dynamix.Activation one)
    {
      activationsWithArgument.Add(one);
    }
    
    private List<Dynamix.Activation> activationsWithReceiver = new List<Dynamix.Activation>();
    
    [FameProperty(Name = "activationsWithReceiver",  Opposite = "receiver")]    
    public List <Dynamix.Activation> ActivationsWithReceiver
    {
      get { return activationsWithReceiver; }
      set { activationsWithReceiver = value; }
    }
    public void AddActivationsWithReceiver(Dynamix.Activation one)
    {
      activationsWithReceiver.Add(one);
    }
    
    private List<Dynamix.Activation> activationsWithReturn = new List<Dynamix.Activation>();
    
    [FameProperty(Name = "activationsWithReturn",  Opposite = "return")]    
    public List <Dynamix.Activation> ActivationsWithReturn
    {
      get { return activationsWithReturn; }
      set { activationsWithReturn = value; }
    }
    public void AddActivationsWithReturn(Dynamix.Activation one)
    {
      activationsWithReturn.Add(one);
    }
    
  }
}
