using System;
using Entitas;
using UnityEngine;

public class TakePowerupsSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;
    private Contexts _contexts;

    public TakePowerupsSystem(Contexts contexts)
    {
        _contexts = contexts;
        _entities = contexts.game.GetGroup(GameMatcher.Powerup);
    }

    public void Execute()
    {
        if (!_contexts.game.isPlayer)
            return;

        var playerPosition = _contexts.game.playerEntity.tilemapPosition.value;
        var playerPixelOffset = _contexts.game.playerEntity.pixelOffset.value;

        // player is too far from the center
        if (Mathf.Abs(playerPixelOffset.x) > 4 || Mathf.Abs(playerPixelOffset.y) > 4)
            return;
        
        foreach (var e in _entities)
        {
            if (e.tileId.value != playerPosition)
                continue;

            e.isDestroyed = true;

            switch (e.powerup.value)
            {
                case PowerupType.Fire:
                    PlayerState.sharedInstance.bombRange++;
                    break;
                
                case PowerupType.Bomb:
                    PlayerState.sharedInstance.bombsAvailable++;
                    break;
                
                case PowerupType.Detonator:
                    PlayerState.sharedInstance.hasDetonator = true;
                    break;
                
                case PowerupType.Speedup:
                    PlayerState.sharedInstance.hasSpeedup = true;
                    break;
                
                case PowerupType.BombWalk:
                    break;
                
                case PowerupType.WallWalker:
                    break;
                
                case PowerupType.FlameProof:
                    break;
                
                case PowerupType.Mystery:
                    break;
            }
        }
    }
}