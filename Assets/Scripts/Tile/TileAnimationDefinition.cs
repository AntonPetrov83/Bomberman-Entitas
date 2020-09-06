using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TileAnimationDefinition : ScriptableObject
{
    [SerializeField] private Tile[] _tiles;
    [SerializeField] private int _speed;
    [SerializeField] private bool _looped;

    public int frameCount => _tiles.Length;
    
    public int speed => _speed;
    
    public bool looped => _looped;

    public float length => frameCount / (float) speed;

    public Tile GetTile(float time)
    {
        var index = GetTileIndex(time);
        return index >= 0
            ? _tiles[index]
            : null;
    }

    public int GetTileIndex(float time)
    {
        if (_tiles == null || _tiles.Length == 0)
            return -1;

        // TODO: Use integer as frame time counter.
        var frame = (int)(time * _speed);

        if (_looped)
            return frame % _tiles.Length;

        return frame > _tiles.Length - 1 ? _tiles.Length - 1 : frame;
    }        
}