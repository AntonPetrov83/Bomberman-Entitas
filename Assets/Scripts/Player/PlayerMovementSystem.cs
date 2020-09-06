using System.Linq;
using Entitas;
using UnityEngine;

public sealed class PlayerMovementSystem : IExecuteSystem
{
    private readonly Contexts _contexts;

    public PlayerMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    
    public void Execute()
    {
        var playerEntity = _contexts.game.playerEntity;
        if (playerEntity == null)
            return;

        if (!playerEntity.hasVelocity)
            return;
        
        var velocity = playerEntity.velocity.value;
        var tilemapPosition = Vector2Int.zero;
        var pixelOffset = Vector2.zero;

        if (playerEntity.hasTilemapPosition)
            tilemapPosition = playerEntity.tilemapPosition.value;
        
        if (playerEntity.hasPixelOffset)
            pixelOffset = playerEntity.pixelOffset.value;
        
        // clamp velocity if cannot move there.
        if (velocity.x < 0 && pixelOffset.x <= 0)
        {
            if (!IsNextTileWalkable(-1, 0))
            {
                velocity.x = 0;
                pixelOffset.x = 0;
            }
        }
        else if (velocity.x > 0 && pixelOffset.x >= 0)
        {
            if (!IsNextTileWalkable(1, 0))
            {
                velocity.x = 0;
                pixelOffset.x = 0;
            }
        }
        
        if (velocity.y < 0 && pixelOffset.y <= 0)
        {
            if (!IsNextTileWalkable(0, -1))
            {
                velocity.y = 0;
                pixelOffset.y = 0;
            }
        }
        else if (velocity.y > 0 && pixelOffset.y >= 0)
        {
            if (!IsNextTileWalkable(0, 1))
            {
                velocity.y = 0;
                pixelOffset.y = 0;
            }
        }
        
        // apply velocity to the pixel offset.
        pixelOffset += new Vector2(
            velocity.x * 16 * Time.deltaTime,
            velocity.y * 16 * Time.deltaTime);

        // convert pixel offset overflow to a new tilemap position.
        while (pixelOffset.x > 8)
        {
            pixelOffset.x -= 16;
            tilemapPosition.x += 1;
        }
        
        while (pixelOffset.x < -8)
        {
            pixelOffset.x += 16;
            tilemapPosition.x -= 1;
        }        

        while (pixelOffset.y > 8)
        {
            pixelOffset.y -= 16;
            tilemapPosition.y += 1;
        }
        
        while (pixelOffset.y < -8)
        {
            pixelOffset.y += 16;
            tilemapPosition.y -= 1;
        } 
        
        // push to the center of a tile.
        if (velocity.x != 0)
        {
            var speed = Mathf.Abs(velocity.x) * 16;

            if (pixelOffset.y < 0)
                pixelOffset.y = Mathf.Min(pixelOffset.y + speed * Time.deltaTime, 0);
            
            else if (pixelOffset.y > 0)
                pixelOffset.y = Mathf.Max(pixelOffset.y - speed * Time.deltaTime, 0);
        }
        else if (velocity.y != 0)
        {
            var speed = Mathf.Abs(velocity.y) * 16;
            
            if (pixelOffset.x < 0)
                pixelOffset.x = Mathf.Min(pixelOffset.x + speed * Time.deltaTime, 0);
            
            else if (pixelOffset.x > 0)
                pixelOffset.x = Mathf.Max(pixelOffset.x - speed * Time.deltaTime, 0);
        }
        
        playerEntity.ReplaceTilemapPosition(tilemapPosition);
        playerEntity.ReplacePixelOffset(pixelOffset);
        
        bool IsNextTileWalkable(int dx, int dy)
        {
            var tileId = new Vector2Int(tilemapPosition.x + dx, tilemapPosition.y + dy);
            var tileEntities = _contexts.game.GetEntitiesWithTileId(tileId);
            if (tileEntities.Count == 0)
                return true;

            return tileEntities.First().isWalkable;
        }
    }
}