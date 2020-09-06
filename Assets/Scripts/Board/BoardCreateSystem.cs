using System.Collections.Generic;
using Entitas;
using UnityEngine;

public class BoardCreateSystem : IInitializeSystem
{
    private const int Width = 31;
    private const int Height = 13;

    private readonly GameContext _context;
    private readonly IResources _resources;
    private readonly ILevels _levels;

    public BoardCreateSystem(Contexts contexts)
    {
        _context = contexts.game;
        _resources = contexts.config.resources.value;
        _levels = contexts.config.levels.value;
    }
        
    public void Initialize()
    {
        InitializeHeader();

        var emptyCells = new List<Vector2Int>();
        
        InitializeHardWalls(emptyCells);

        InitializeLevel(_levels.levels[0], emptyCells);
    }

    private void InitializeHeader()
    {
        for (int j = -2; j < 0; ++j)
        {
            for (int i = 0; i < Width; ++i)
            {
                _context.CreateEmptyTile(i, j, _resources);
            }
        }
    }
    
    private void InitializeHardWalls(List<Vector2Int> emptyCells)
    {
        for (int j = 0; j < Height; ++j)
        {
            for (int i = 0; i < Width; ++i)
            {
                if (j == 0 || j == Height - 1)
                    _context.CreateWallTile(i, j, _resources);

                else if (i == 0 || i == Width - 1)
                    _context.CreateWallTile(i, j, _resources);

                else if (i % 2 == 0 && j % 2 == 0)
                    _context.CreateWallTile(i, j, _resources);

                else
                    emptyCells.Add(new Vector2Int(i, j));
            }
        }
    }

    private void InitializeLevel(LevelDefinition level, List<Vector2Int> emptyCells)
    {
        // force player spawn point to be empty.
        emptyCells.Remove(new Vector2Int(1, 1));
        emptyCells.Remove(new Vector2Int(1, 2));
        emptyCells.Remove(new Vector2Int(2, 1));
        
        // generate brick walls.
        for (int k = 0; k < level.wallsCount; ++k)
        {
            var idx = Random.Range(0, emptyCells.Count);
            var cell = emptyCells[idx];
            emptyCells.RemoveAt(idx);

            var e = _context.CreateBrickWall(cell.x, cell.y, _resources); //.id.value;
            
            // add a door and a power-up.
            if (k == 0)
                e.AddHiddenPowerup(PowerupType.Door);
            else if (k == 1 && level.powerup != PowerupType.None)
                e.AddHiddenPowerup(level.powerup);
        }
        
        // generate enemies.
        for (int i = 0; i < level.enemies.valcom; i++)
        {
            var idx = Random.Range(0, emptyCells.Count);
            var cell = emptyCells[idx];
            emptyCells.RemoveAt(idx);

            _context.CreateBallom(cell, _resources);
        }
    }
}