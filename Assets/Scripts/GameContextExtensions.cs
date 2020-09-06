using System;
using UnityEngine;

public static class GameContextExtensions
{
    public static GameEntity CreateBomberman(this GameContext context, int x, int y, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.isPlayer = true;
        entity.AddTilemapPosition(new Vector2Int(x, y));
        entity.AddPixelOffset(Vector2.zero);
        entity.AddAnimation(resources.bombermanLeft);        

        return entity;
    }
    
    public static GameEntity CreateBombermanDeath(this GameContext context, Vector2Int tilemapPosition, Vector2 pixelOffset, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.isAutoDestroyedWhenAnimationEnds = true;
        entity.AddTilemapPosition(tilemapPosition);
        entity.AddPixelOffset(pixelOffset);
        entity.AddAnimation(resources.bombermanDeath);
        entity.AddAnimationTime(Time.time);

        return entity;
    }
    
    public static GameEntity CreateBallom(this GameContext context, Vector2Int pos, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.isBallom = true;
        entity.AddEnemy(EnemyType.Ballom);
        entity.AddTilemapPosition(pos);
        entity.AddPixelOffset(Vector2.zero);
        entity.AddAnimation(resources.ballomLeft);        
        entity.AddAnimationTime(Time.time);
        
        return entity;
    }

    public static GameEntity CreateEnemyDeath(this GameContext context, EnemyType enemyType, Vector2Int tilemapPosition, Vector2 pixelOffset, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.isAutoDestroyedWhenAnimationEnds = true;
        entity.AddTilemapPosition(tilemapPosition);
        entity.AddPixelOffset(pixelOffset);
        entity.AddAnimationTime(Time.time);
        
        switch (enemyType)
        {
            default:
                entity.AddAnimation(resources.ballomDeath);
                break;
        }
        
        return entity;
    }

    public static GameEntity CreateEmptyTile(this GameContext context, int x, int y, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.AddTileId(new Vector2Int(x, y));
        entity.AddTilemapPosition(new Vector2Int(x, y));
        entity.AddTileAsset(resources.emptyTile);
        return entity;
    }
    
    public static GameEntity CreateWallTile(this GameContext context, int x, int y, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.AddTileId(new Vector2Int(x, y));
        entity.AddTilemapPosition(new Vector2Int(x, y));
        entity.AddTileAsset(resources.hardWallTile);
        return entity;
    }
    
    public static GameEntity CreateBrickWall(this GameContext context, int x, int y, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.isBrickWall = true;
        entity.isFlamable = true;
        entity.AddTileId(new Vector2Int(x, y));
        entity.AddTilemapPosition(new Vector2Int(x, y));
        entity.AddTileAsset(resources.brickWallTile);
        return entity;
    }
    
    public static GameEntity CreateDoor(this GameContext context, Vector2Int position, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.isDoor = true;
        entity.isFlamable = true;
        entity.isWalkable = true;
        entity.AddTileId(position);
        entity.AddTilemapPosition(position);
        entity.AddTileAsset(resources.doorTile);
        return entity;
    }

    public static GameEntity CreatePowerup(this GameContext context, PowerupType powerupType, Vector2Int position, IResources resources)
    {
        if (powerupType == PowerupType.Door)
            return context.CreateDoor(position, resources);
        
        var entity = context.CreateEntity();
        entity.isFlamable = true;
        entity.isWalkable = true;
        entity.AddPowerup(powerupType);
        entity.AddTileId(position);
        entity.AddTilemapPosition(position);

        switch (powerupType)
        {
            case PowerupType.Fire:
                entity.AddTileAsset(resources.firePowerupTile);
                break;
            
            case PowerupType.Bomb:
                entity.AddTileAsset(resources.bombPowerupTile);
                break;
            
            case PowerupType.Detonator:
                entity.AddTileAsset(resources.detonatorPowerupTile);
                break;
            
            case PowerupType.Speedup:
                entity.AddTileAsset(resources.speedupPowerupTile);
                break;
            
            case PowerupType.BombWalk:
                break;
            
            case PowerupType.WallWalker:
                break;
            
            case PowerupType.FlameProof:
                break;
            
            case PowerupType.Mystery:
                break;
            
            default:
                throw new ArgumentOutOfRangeException(nameof(powerupType), powerupType, null);
        }
        
        return entity;
    }

    public static GameEntity CreateBomb(this GameContext context, int x, int y, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.isBomb = true;
        entity.isFlamable = true;
        entity.AddTileId(new Vector2Int(x, y));
        entity.AddTilemapPosition(new Vector2Int(x, y));
        entity.AddTileAnimationAsset(resources.bombTileAnimation);
        entity.AddAnimationTime(Time.time);
    
        return entity;
    }
    
    public static GameEntity CreateExplosion(this GameContext context, int x, int y, int range, IResources resources)
    {
        var entity = context.CreateEntity();
        entity.isExploded = true;
        entity.isAutoDestroyedWhenAnimationEnds = true;
        entity.isWalkable = true;
        entity.AddFire(MoveDirections.All, range, Time.time);
        entity.AddTileId(new Vector2Int(x, y));
        entity.AddTilemapPosition(new Vector2Int(x, y));
        entity.AddTileAnimationAsset(resources.explosionCenterTileAnimation);
        entity.AddAnimationTime(Time.time);

        return entity;
    }
    
    private static GameEntity CreateBaseExplosion(this GameContext context, int x, int y, int range)
    {
        var entity = context.CreateEntity();
        entity.isExploded = true;
        entity.isAutoDestroyedWhenAnimationEnds = true;
        entity.isWalkable = true;
        entity.AddTileId(new Vector2Int(x, y));
        entity.AddTilemapPosition(new Vector2Int(x, y));
        entity.AddAnimationTime(Time.time);

        return entity;
    }      
    
    public static GameEntity CreateUpExplosion(this GameContext context, int x, int y, int range, IResources resources)
    {
        var entity = context.CreateBaseExplosion(x, y, range);
        entity.AddFire(MoveDirections.Up, range, Time.time);
        entity.AddTileAnimationAsset(range >= 1 ? resources.explosionVerticalTileAnimation : resources.explosionUpTileAnimation);
        return entity;
    }
    
    public static GameEntity CreateDownExplosion(this GameContext context, int x, int y, int range, IResources resources)
    {
        var entity = context.CreateBaseExplosion(x, y, range);
        entity.AddFire(MoveDirections.Down, range, Time.time);
        entity.AddTileAnimationAsset(range >= 1 ? resources.explosionVerticalTileAnimation : resources.explosionDownTileAnimation);
        return entity;
    }
    
    public static GameEntity CreateLeftExplosion(this GameContext context, int x, int y, int range, IResources resources)
    {
        var entity = context.CreateBaseExplosion(x, y, range);
        entity.AddFire(MoveDirections.Left, range, Time.time);
        entity.AddTileAnimationAsset(range >= 1 ? resources.explosionHorizontalTileAnimation : resources.explosionLeftTileAnimation);
        return entity;
    }      
    
    public static GameEntity CreateRightExplosion(this GameContext context, int x, int y, int range, IResources resources)
    {
        var entity = context.CreateBaseExplosion(x, y, range);
        entity.AddFire(MoveDirections.Right, range, Time.time);
        entity.AddTileAnimationAsset(range >= 1 ? resources.explosionHorizontalTileAnimation : resources.explosionRightTileAnimation);
        return entity;
    }    
}
