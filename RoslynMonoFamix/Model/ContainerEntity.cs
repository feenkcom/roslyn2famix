using Fame;
using System;
using System.Collections.Generic;

namespace FAMIX
{
  [FamePackage("FAMIX")]
  [FameDescription("ContainerEntity")]
  public class ContainerEntity : NamedEntity
  {
    private List<Function> functions = new List<Function>();
    
    [FameProperty(Name = "functions",  Opposite = "container")]    
    public List Functions
    {
      { return Functions; }
      { Functions = value; }
    }
    public void AddFunction(Function one)
    {
      Functions.Add(one);
    }
    
    private List<Type> types = new List<Type>();
    
    [FameProperty(Name = "types",  Opposite = "container")]    
    public List Types
    {
      { return Types; }
      { Types = value; }
    }
    public void AddType(Type one)
    {
      Types.Add(one);
    }
    
    private List<AnnotationType> definedAnnotationTypes = new List<AnnotationType>();
    
    [FameProperty(Name = "definedAnnotationTypes",  Opposite = "container")]    
    public List DefinedAnnotationTypes
    {
      { return DefinedAnnotationTypes; }
      { DefinedAnnotationTypes = value; }
    }
    public void AddAnnotationType(AnnotationType one)
    {
      DefinedAnnotationTypes.Add(one);
    }
    
  }
}
