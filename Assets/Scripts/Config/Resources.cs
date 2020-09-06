using Animation;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class Resources : ScriptableObject, IResources
{
    [Header("Sprite Animations")]
    [SerializeField] private AnimationDefinition _bombermanLeft;
    [SerializeField] private AnimationDefinition _bombermanRight;
    [SerializeField] private AnimationDefinition _bombermanUp;
    [SerializeField] private AnimationDefinition _bombermanDown;
    [SerializeField] private AnimationDefinition _bombermanDeath;
    [SerializeField] private AnimationDefinition _ballomLeft;
    [SerializeField] private AnimationDefinition _ballomRight;
    [SerializeField] private AnimationDefinition _ballomDeath;

    [Header("Tile Animations")]
    [SerializeField] private TileAnimationDefinition _bombTileAnimation;
    [SerializeField] private TileAnimationDefinition _brickWallExplosionTileAnimation;
    [SerializeField] private TileAnimationDefinition _explosionCenterTileAnimation;
    [SerializeField] private TileAnimationDefinition _explosionHorizontalTileAnimation;
    [SerializeField] private TileAnimationDefinition _explosionVerticalTileAnimation;
    [SerializeField] private TileAnimationDefinition _explosionLeftTileAnimation;
    [SerializeField] private TileAnimationDefinition _explosionRightTileAnimation;
    [SerializeField] private TileAnimationDefinition _explosionUpTileAnimation;
    [SerializeField] private TileAnimationDefinition _explosionDownTileAnimation;
    
    [Header("Tiles")]
    [SerializeField] private Tile _emptyTile;
    [SerializeField] private Tile _hardWallTile;
    [SerializeField] private Tile _brickWallTile;
    [SerializeField] private Tile _doorTile;
    [SerializeField] private Tile _firePowerupTile;
    [SerializeField] private Tile _bombPowerupTile;
    [SerializeField] private Tile _detonatorPowerupTile;
    [SerializeField] private Tile _speedupPowerupTile;

    public AnimationDefinition bombermanLeft => _bombermanLeft;
    public AnimationDefinition bombermanRight => _bombermanRight;
    public AnimationDefinition bombermanUp => _bombermanUp;
    public AnimationDefinition bombermanDown => _bombermanDown;
    public AnimationDefinition bombermanDeath => _bombermanDeath;
    public AnimationDefinition ballomLeft => _ballomLeft;
    public AnimationDefinition ballomRight => _ballomRight;
    public AnimationDefinition ballomDeath => _ballomDeath;

    public TileAnimationDefinition explosionCenterTileAnimation => _explosionCenterTileAnimation;
    public TileAnimationDefinition explosionHorizontalTileAnimation => _explosionHorizontalTileAnimation;
    public TileAnimationDefinition explosionVerticalTileAnimation => _explosionVerticalTileAnimation;
    public TileAnimationDefinition explosionLeftTileAnimation => _explosionLeftTileAnimation;
    public TileAnimationDefinition explosionRightTileAnimation => _explosionRightTileAnimation;
    public TileAnimationDefinition explosionUpTileAnimation => _explosionUpTileAnimation;
    public TileAnimationDefinition explosionDownTileAnimation => _explosionDownTileAnimation;
    
    
    public TileAnimationDefinition bombTileAnimation => _bombTileAnimation;
    public TileAnimationDefinition brickWallExplosionTileAnimation => _brickWallExplosionTileAnimation;

    public Tile emptyTile => _emptyTile;
    public Tile hardWallTile => _hardWallTile;
    public Tile brickWallTile => _brickWallTile;
    public Tile doorTile => _doorTile;
    public Tile firePowerupTile => _firePowerupTile;
    public Tile bombPowerupTile => _bombPowerupTile;
    public Tile detonatorPowerupTile => _detonatorPowerupTile;
    public Tile speedupPowerupTile => _speedupPowerupTile;
}