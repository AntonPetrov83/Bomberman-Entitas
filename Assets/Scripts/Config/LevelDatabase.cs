using UnityEngine;

[CreateAssetMenu]
public class LevelDatabase : ScriptableObject, ILevels
{
    [SerializeField] private LevelDefinition[] _levels;

    public LevelDefinition[] levels => _levels;
}