using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ContainerEntity")]
  public class ContainerEntity : FAMIX.NamedEntity
  {
    private List<Type> types = new List<Type>();
    
    [FameProperty(Name = "types",  Opposite = "container")]    
    public List <Type> Types
    {
      get { return types; }
      set { types = value; }
    }
    public void AddType(Type one)
    {
      types.Add(one);
    }
    
    private List<AnnotationType> definedAnnotationTypes = new List<AnnotationType>();
    
    [FameProperty(Name = "definedAnnotationTypes",  Opposite = "container")]    
    public List <AnnotationType> DefinedAnnotationTypes
    {
      get { return definedAnnotationTypes; }
      set { definedAnnotationTypes = value; }
    }
    public void AddDefinedAnnotationType(AnnotationType one)
    {
      definedAnnotationTypes.Add(one);
    }
    
    private List<Function> functions = new List<Function>();
    
    [FameProperty(Name = "functions",  Opposite = "container")]    
    public List <Function> Functions
    {
      get { return functions; }
      set { functions = value; }
    }
    public void AddFunction(Function one)
    {
      functions.Add(one);
    }
    
  }
}
