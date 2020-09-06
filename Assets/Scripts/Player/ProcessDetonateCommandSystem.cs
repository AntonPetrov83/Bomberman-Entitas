using System.Collections.Generic;
using Entitas;

public sealed class ProcessDetonateCommandSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly IResources _resources;
    private readonly IGroup<GameEntity> _bombs;
    
    public ProcessDetonateCommandSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _resources = contexts.config.resources.value;
        _bombs = contexts.game.GetGroup(GameMatcher.Bomb);
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.DetonateCommand);

    protected override bool Filter(GameEntity entity)
        => entity.isDetonateCommand;

    protected override void Execute(List<GameEntity> entities)
    {
        if (!PlayerState.sharedInstance.hasDetonator)
            return;
        
        foreach (var e in _bombs)
        {
            if (!e.isExploded)
                e.isExploded = true;
        }
    }
}