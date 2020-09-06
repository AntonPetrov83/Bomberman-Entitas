using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddTileCreationTimeSystem : ReactiveSystem<GameEntity>
{
    public AddTileCreationTimeSystem(Contexts contexts) : base(contexts.game)
    { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.TileId);

    protected override bool Filter(GameEntity entity)
        => !entity.hasTileCreationTime; 

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.AddTileCreationTime(Time.time);
        }
    }
}