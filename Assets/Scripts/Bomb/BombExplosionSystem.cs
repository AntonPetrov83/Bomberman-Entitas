using System.Collections.Generic;
using Entitas;

public class BombExplosionSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly IResources _resources;

    public BombExplosionSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _resources = contexts.config.resources.value;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Exploded);

    protected override bool Filter(GameEntity entity)
        => entity.isBomb && entity.isExploded && !entity.isDestroyed;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isDestroyed = true;
            
            var tilemapPosition = e.tilemapPosition.value;
            
            _contexts.game.CreateExplosion(tilemapPosition.x, tilemapPosition.y, 
                PlayerState.sharedInstance.bombRange,
                _resources);
        }
    }
}