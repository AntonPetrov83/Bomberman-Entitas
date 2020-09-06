using System;
using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique]
public sealed class GameTime : IComponent
{
    public TimeSpan value;
}