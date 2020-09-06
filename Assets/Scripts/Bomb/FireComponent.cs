using Entitas;

public sealed class FireComponent : IComponent
{
    public MoveDirections directions;
    public int range;
    public float time;
}