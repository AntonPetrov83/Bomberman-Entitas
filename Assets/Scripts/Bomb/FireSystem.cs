using System;
using System.Collections.Generic;
using System.Linq;
using Entitas;
using UnityEngine;

public class FireSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IGroup<GameEntity> _entities;

    public FireSystem(Contexts contexts)
    {
        _contexts = contexts;
        _entities = contexts.game.GetGroup(GameMatcher.Fire);
    }
    
    public void Execute()
    {
        var now = Time.time;
        
        foreach (var e in _entities.GetEntities())
        {
            if (now - e.fire.time < 0.03f)
                continue;

            PropagateFire(e.fire, e.tileId.value);
            
            e.RemoveFire();
        }
    }

    private void PropagateFire(FireComponent fire, Vector2Int pos)
    {
        if (fire.range == 0)
            return;
        
        if (fire.directions.HasFlag(MoveDirections.Up))
        {
            FireTile(new Vector2Int(pos.x, pos.y - 1), fire.range - 1, MoveDirections.Up);
        }

        if (fire.directions.HasFlag(MoveDirections.Down))
        {
            FireTile(new Vector2Int(pos.x, pos.y + 1), fire.range - 1, MoveDirections.Down);
        }

        if (fire.directions.HasFlag(MoveDirections.Left))
        {
            FireTile(new Vector2Int(pos.x - 1, pos.y), fire.range - 1, MoveDirections.Left);
        }
        
        if (fire.directions.HasFlag(MoveDirections.Right))
        {
            FireTile(new Vector2Int(pos.x + 1, pos.y), fire.range - 1, MoveDirections.Right);
        }
    }

    private void FireTile(Vector2Int pos, int range, MoveDirections direction)
    {
        var tiles = _contexts.game.GetEntitiesWithTileId(pos);

        if (tiles.Count == 0)
        {
            switch (direction)
            {
                case MoveDirections.Left:
                    _contexts.game.CreateLeftExplosion(pos.x, pos.y, range, _contexts.config.resources.value);
                    break;
                
                case MoveDirections.Right:
                    _contexts.game.CreateRightExplosion(pos.x, pos.y, range, _contexts.config.resources.value);
                    break;
                
                case MoveDirections.Up:
                    _contexts.game.CreateUpExplosion(pos.x, pos.y, range, _contexts.config.resources.value);
                    break;

                case MoveDirections.Down:
                    _contexts.game.CreateDownExplosion(pos.x, pos.y, range, _contexts.config.resources.value);
                    break;
            }
        }
        else
        {
            var e = tiles.First();

            if (e.isFlamable)
            {
                e.isExploded = true;
            }
        }        
    }
}