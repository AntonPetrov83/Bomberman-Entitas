using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

public class TileIdComponent : IComponent
{
    [EntityIndex] public Vector2Int value;
}