using System;
using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GameController
{
    readonly Systems _systems;
    
    public GameController(Contexts contexts, IResources resources, ILevels levels, Tilemap tilemap)
    {
        contexts.config.SetResources(resources);
        contexts.config.SetLevels(levels);

        contexts.game.SetTilemap(tilemap);
    
        // This is the heart of Match One:
        // All logic is contained in all the sub systems of GameSystems
        _systems = new GameSystems(contexts);
    }
    
    public void Initialize()
    {
        // This calls Initialize() on all sub systems
        _systems.Initialize();
    }
    
    public void Execute()
    {
        // This calls Execute() and Cleanup() on all sub systems
        _systems.Execute();
        _systems.Cleanup();
    }
}