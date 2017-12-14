using Fame;
using System;
using FILE;
using Dynamix;
using FAMIX;
using System.Collections.Generic;

namespace FILE
{
  [FamePackage("FILE")]
  [FameDescription("File")]
  public class File : FILE.AbstractFile
  {
    [FameProperty(Name = "numberOfExternalClones")]    
    public int numberOfExternalClones { get; set; }
    
    [FameProperty(Name = "totalNumberOfLinesOfText")]    
    public int totalNumberOfLinesOfText { get; set; }
    
    [FameProperty(Name = "numberOfInternalDuplications")]    
    public int numberOfInternalDuplications { get; set; }
    
    [FameProperty(Name = "numberOfInternalMultiplications")]    
    public int numberOfInternalMultiplications { get; set; }
    
    private List<SourcedEntity> entities = new List<SourcedEntity>();
    
    [FameProperty(Name = "entities",  Opposite = "containerFiles")]    
    public List <SourcedEntity> Entities
    {
      get { return entities; }
      set { entities = value; }
    }
    public void AddEntitie(SourcedEntity one)
    {
      entities.Add(one);
    }
    
    [FameProperty(Name = "numberOfDuplicatedFiles")]    
    public int numberOfDuplicatedFiles { get; set; }
    
    [FameProperty(Name = "numberOfBytes")]    
    public int numberOfBytes { get; set; }
    
    [FameProperty(Name = "numberOfInternalClones")]    
    public int numberOfInternalClones { get; set; }
    
    [FameProperty(Name = "averageNumberOfCharactersPerLine")]    
    public int averageNumberOfCharactersPerLine { get; set; }
    
    [FameProperty(Name = "numberOfCharacters")]    
    public int numberOfCharacters { get; set; }
    
    [FameProperty(Name = "numberOfEmptyLinesOfText")]    
    public int numberOfEmptyLinesOfText { get; set; }
    
    [FameProperty(Name = "numberOfKiloBytes")]    
    public int numberOfKiloBytes { get; set; }
    
    [FameProperty(Name = "numberOfExternalDuplications")]    
    public int numberOfExternalDuplications { get; set; }
    
  }
}
