using Animation;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;
using UnityEngine.Tilemaps;

[Config, Unique, ComponentName("Resources")]
public interface IResources
{
    AnimationDefinition bombermanLeft { get; }
    AnimationDefinition bombermanRight { get; }
    AnimationDefinition bombermanUp { get; }
    AnimationDefinition bombermanDown { get; }
    AnimationDefinition bombermanDeath { get; }
    AnimationDefinition ballomLeft { get; }
    AnimationDefinition ballomRight { get; }
    AnimationDefinition ballomDeath { get; }
    
        
    TileAnimationDefinition explosionCenterTileAnimation { get; }
    TileAnimationDefinition explosionHorizontalTileAnimation { get; }
    TileAnimationDefinition explosionVerticalTileAnimation { get; }
    TileAnimationDefinition explosionLeftTileAnimation { get; }
    TileAnimationDefinition explosionRightTileAnimation { get; }
    TileAnimationDefinition explosionUpTileAnimation { get; }
    TileAnimationDefinition explosionDownTileAnimation { get; }
    TileAnimationDefinition bombTileAnimation { get; }
    TileAnimationDefinition brickWallExplosionTileAnimation { get; }
    
    Tile emptyTile { get; }
    Tile hardWallTile { get; }
    Tile brickWallTile { get; }
    Tile doorTile { get; }
    Tile firePowerupTile { get; }
    Tile bombPowerupTile { get; }
    Tile detonatorPowerupTile { get; }
    Tile speedupPowerupTile { get; }
}