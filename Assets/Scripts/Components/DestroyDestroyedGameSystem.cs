using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.Tilemaps;

public sealed class DestroyDestroyedSystem : ICleanupSystem
{
    private readonly Tilemap _tilemap;
    private readonly IGroup<GameEntity> _group;
    private readonly List<GameEntity> _buffer = new List<GameEntity>();

    public DestroyDestroyedSystem(Contexts contexts)
    {
        _tilemap = contexts.game.tilemap.value;
        _group = contexts.game.GetGroup(GameMatcher.Destroyed);
    }

    public void Cleanup()
    {
        foreach (var e in _group.GetEntities(_buffer))
        {
            // remove tile.
            if (e.hasTileId && e.hasTileAsset)
            {
                // TODO: Do not reset tile if it belongs to another sprite.
                var tilePos = new Vector3Int(e.tileId.value.x, -e.tileId.value.y - 1, 0); 
                _tilemap.SetTile(tilePos, null);
            }
                
            e.Destroy();
        }
    }
}