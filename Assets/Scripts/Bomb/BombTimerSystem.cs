using Entitas;
using UnityEngine;

public class BombTimerSystem : IExecuteSystem
{
    private readonly Contexts _contexts;
    private readonly IResources _resources;
    private const float BombTimeout = 3;
    
    private readonly IGroup<GameEntity> _entities;

    public BombTimerSystem(Contexts contexts)
    {
        _contexts = contexts;
        _resources = contexts.config.resources.value;
        _entities = contexts.game.GetGroup(GameMatcher.Bomb);
    }
    
    public void Execute()
    {
        if (PlayerState.sharedInstance.hasDetonator)
            return;
            
        var now = Time.time;
        
        foreach (var e in _entities)
        {
            if (!e.hasTileCreationTime)
                continue;
            
            if (e.isExploded)
                continue;

            if (now - e.tileCreationTime.value < BombTimeout)
                continue;

            e.isExploded = true;
        }
    }
}