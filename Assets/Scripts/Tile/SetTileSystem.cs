using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class SetTileSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public SetTileSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.TileAsset);

    protected override bool Filter(GameEntity entity)
        => entity.hasTileAsset && entity.hasTileId;

    protected override void Execute(List<GameEntity> entities)
    {
        var tilemap = _contexts.game.tilemap.value;
        
        foreach (var e in entities)
        {
            var tile = e.tileAsset.value;
            var id = e.tileId.value;
            tilemap.SetTile(new Vector3Int(id.x, -id.y - 1, 0), tile );
        }
    }
}