using System.Collections.Generic;
using Entitas;

public sealed class ProcessBombCommandSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private readonly IResources _resources;
    private readonly IGroup<GameEntity> _bombs;
    
    public ProcessBombCommandSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _resources = contexts.config.resources.value;
        _bombs = contexts.game.GetGroup(GameMatcher.Bomb);
    }
    
    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.BombCommand);

    protected override bool Filter(GameEntity entity)
        => entity.isBombCommand;

    protected override void Execute(List<GameEntity> entities)
    {
        if (!_contexts.game.isPlayer)
            return;

        // no more bombs.
        if (PlayerState.sharedInstance.bombsAvailable <= _bombs.count)
            return;

        var player = _contexts.game.playerEntity;
        if (!player.hasTilemapPosition)
            return;
        
        var tilemapPosition = player.tilemapPosition.value;

        // cell is not empty.
        if (_contexts.game.GetEntitiesWithTileId(tilemapPosition).Count > 0)
            return;
        
        _contexts.game.CreateBomb(tilemapPosition.x, tilemapPosition.y, _resources);
    }
}