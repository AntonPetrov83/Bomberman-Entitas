using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Game, Unique]
public sealed class PlayerComponent : IComponent
{
}

[Game]
public sealed class BombCommandComponent : IComponent
{
}

[Game]
public sealed class DetonateCommandComponent : IComponent
{
}

[Game]
public sealed class MoveCommandComponent : IComponent
{
    public MoveDirections value;
}

[Game]
public sealed class VelocityComponent : IComponent
{
    public Vector2 value;
}