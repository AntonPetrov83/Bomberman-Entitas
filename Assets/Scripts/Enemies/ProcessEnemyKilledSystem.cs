using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class ProcessEnemyKilledSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;
    private IResources _resources;
    
    public ProcessEnemyKilledSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
        _resources = contexts.config.resources.value;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.AllOf(GameMatcher.Killed, GameMatcher.Enemy));

    protected override bool Filter(GameEntity entity)
        => entity.isKilled && !entity.isAutoDestroyedWhenAnimationEnds;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.isDestroyed = true;

            _contexts.game.CreateEnemyDeath(e.enemy.value, e.tilemapPosition.value, e.pixelOffset.value, _resources);
        }
    }
}