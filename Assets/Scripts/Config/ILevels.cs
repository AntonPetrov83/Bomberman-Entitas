
using Entitas.CodeGeneration.Attributes;

[Config, Unique, ComponentName("Levels")]
public interface ILevels
{
    LevelDefinition[] levels { get; }
}