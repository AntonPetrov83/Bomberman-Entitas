using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine.Tilemaps;

[Unique]
public sealed class TilemapComponent : IComponent
{
    public Tilemap value;
}