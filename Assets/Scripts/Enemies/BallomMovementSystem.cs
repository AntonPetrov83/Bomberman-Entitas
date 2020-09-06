using System.Linq;
using Entitas;
using UnityEngine;

public class BallomMovementSystem : IExecuteSystem
{
    private Contexts _contexts;
    private IGroup<GameEntity> _balloms;

    public BallomMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
        _balloms = contexts.game.GetGroup(GameMatcher.Ballom);
    }
    
    public void Execute()
    {
        foreach (var ballom in _balloms)
        {
            if (ballom.isKilled)
                continue;
            
            // randomize movement direction if it's missing.
            if (!ballom.hasMovementDirection)
            {
                switch (Random.Range(0, 4))
                {
                    case 0:
                        ballom.ReplaceAnimation(_contexts.config.resources.value.ballomLeft);
                        ballom.ReplaceMovementDirection(MoveDirections.Left);
                        break;
                    
                    case 1:
                        ballom.ReplaceAnimation(_contexts.config.resources.value.ballomRight);
                        ballom.ReplaceMovementDirection(MoveDirections.Right);
                        break; 
                    
                    case 2:
                        ballom.ReplaceMovementDirection(MoveDirections.Up);
                        break;
                    
                    case 3:
                        ballom.ReplaceMovementDirection(MoveDirections.Down);
                        break; 
                }
            }

            const float Speed = 2;
            
            var velocity = Vector2.zero;

            switch (ballom.movementDirection.value)
            {
                case MoveDirections.Left:
                    velocity = Speed * Vector2.left;
                    break;
                
                case MoveDirections.Right:
                    velocity = Speed * Vector2.right;
                    break;
                
                case MoveDirections.Up:
                    velocity = Speed * Vector2.down;
                    break;
                
                case MoveDirections.Down:
                    velocity = Speed * Vector2.up;
                    break;
            }
            
            var tilemapPosition = Vector2Int.zero;
            var pixelOffset = Vector2.zero;

            if (ballom.hasTilemapPosition)
                tilemapPosition = ballom.tilemapPosition.value;

            if (ballom.hasPixelOffset)
                pixelOffset = ballom.pixelOffset.value;

            // clamp velocity if cannot move there.
            if (velocity.x < 0 && pixelOffset.x <= 0)
            {
                if (!IsNextTileWalkable(-1, 0))
                {
                    velocity.x = 0;
                    pixelOffset.x = 0;
                    ballom.RemoveMovementDirection();
                }
            }
            else if (velocity.x > 0 && pixelOffset.x >= 0)
            {
                if (!IsNextTileWalkable(1, 0))
                {
                    velocity.x = 0;
                    pixelOffset.x = 0;
                    ballom.RemoveMovementDirection();
                }
            }

            if (velocity.y < 0 && pixelOffset.y <= 0)
            {
                if (!IsNextTileWalkable(0, -1))
                {
                    velocity.y = 0;
                    pixelOffset.y = 0;
                    ballom.RemoveMovementDirection();
                }
            }
            else if (velocity.y > 0 && pixelOffset.y >= 0)
            {
                if (!IsNextTileWalkable(0, 1))
                {
                    velocity.y = 0;
                    pixelOffset.y = 0;
                    ballom.RemoveMovementDirection();
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

            ballom.ReplaceTilemapPosition(tilemapPosition);
            ballom.ReplacePixelOffset(pixelOffset);
           
            
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
}
