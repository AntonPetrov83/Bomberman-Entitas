using Entitas;

public sealed class StartGameSystem : IInitializeSystem
{
    private readonly GameContext _context;
    private readonly IResources _resources;

    public StartGameSystem(Contexts contexts)
    {
        _context = contexts.game;
        _resources = contexts.config.resources.value;
    }

    public void Initialize()
    {
        _context.CreateBomberman(1, 1, _resources);
    }
}