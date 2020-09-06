using System.Collections.Generic;
using Entitas;

public sealed class ProcessPlayerKilledSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public ProcessPlayerKilledSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.AllOf(GameMatcher.Killed, GameMatcher.Player));

    protected override bool Filter(GameEntity entity)
        => entity.isKilled;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isDestroyed = true;
            
            _contexts.game.CreateBombermanDeath(
                e.tilemapPosition.value, 
                e.pixelOffset.value,
                _contexts.config.resources.value);
        }
    }
}