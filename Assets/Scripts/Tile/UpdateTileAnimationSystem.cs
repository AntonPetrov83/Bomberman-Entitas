using Entitas;
using UnityEngine;

public sealed class UpdateTileAnimationSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public UpdateTileAnimationSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.TileAnimationAsset);
    }

    public void Execute()
    {
        var now = Time.time;
        
        foreach (var e in _entities)
        {
            if (!e.hasTileAnimationAsset)
                continue;

            var animation = e.tileAnimationAsset.value;
            
            if (e.hasAnimationTime)
            {
                var time = now - e.animationTime.value;
                
                var tile = animation.GetTile(time);

                if (!e.hasTileAsset || tile != e.tileAsset.value)
                    e.ReplaceTileAsset(tile);

                if (!animation.looped && time >= animation.length)
                {
                    if (e.isAutoDestroyedWhenAnimationEnds)
                        e.isDestroyed = true;
                }
            }
            else
            {
                // initialize sprite.
                if (!e.hasTileAsset)
                    e.ReplaceTileAsset(animation.GetTile(0));
            }
        }
    }
}