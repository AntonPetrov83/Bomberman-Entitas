using Entitas;
using UnityEngine;

public class PlayerKillByEnemySystem : IExecuteSystem
{
    private IGroup<GameEntity> _players;
    private IGroup<GameEntity> _enemies;
    
    public PlayerKillByEnemySystem(Contexts contexts)
    {
        _players = contexts.game.GetGroup(GameMatcher.Player);
        _enemies = contexts.game.GetGroup(GameMatcher.Enemy);
    }
    
    public void Execute()
    {
        foreach (var player in _players)
        {
            var playerHitRect = GetHitRect(player);
            
            foreach (var enemy in _enemies)
            {
                var enemyHitRect = GetHitRect(enemy);

                if (playerHitRect.Overlaps(enemyHitRect))
                {
                    player.isKilled = true;
                    break;
                }
            }
        }
    }

    private static Rect GetHitRect(GameEntity e)
    {
        var tilemapPosition = e.tilemapPosition.value;
        var pixelOffset = e.hasPixelOffset ? e.pixelOffset.value : Vector2.zero;
        
        return new Rect(
            tilemapPosition.x + Mathf.Floor(pixelOffset.x) / 16 + 2 / 16f,
            tilemapPosition.y + Mathf.Floor(pixelOffset.y) / 16 + 2 / 16f,
            12 / 16f,
            12 / 16f );
    }
}