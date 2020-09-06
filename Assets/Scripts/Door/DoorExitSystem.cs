using Entitas;
using UnityEngine;

public class DoorExitSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;
    private Contexts _contexts;

    public DoorExitSystem(Contexts contexts)
    {
        _contexts = contexts;
        _entities = contexts.game.GetGroup(GameMatcher.Door);
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

            // TODO: Exit
        }
    }
}