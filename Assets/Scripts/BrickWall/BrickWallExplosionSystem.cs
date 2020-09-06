using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BrickWallExplosionSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IResources _resources;
    
    private readonly IGroup<GameEntity> _entities;

    public BrickWallExplosionSystem(Contexts contexts)
    {
        _contexts = contexts;
        _resources = contexts.config.resources.value;
        _entities = contexts.game.GetGroup(GameMatcher.Exploded);
    }

    public void Execute()
    {
        var animation = _resources.brickWallExplosionTileAnimation;
        
        foreach (var e in _entities)
        {
            if (!e.isBrickWall)
                continue;
            
            if (e.hasAnimationTime)
            {
                var time = Time.time - e.animationTime.value;
                if (time >= animation.length)
                {
                    e.isDestroyed = true;

                    if (e.hasHiddenPowerup)
                    {
                        _contexts.game.CreatePowerup(e.hiddenPowerup.value, e.tileId.value, _resources);
                    }
                }
            }
            else
            {
                // start brick wall exploded animation.
                e.AddTileAnimationAsset(animation);
                e.AddAnimationTime(Time.time);
            }    
        }
    }
}