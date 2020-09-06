using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class UpdateAnimationTimeSystem : ReactiveSystem<GameEntity>
{
    public UpdateAnimationTimeSystem(Contexts contexts) : base(contexts.game)
    { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Animation);

    protected override bool Filter(GameEntity entity)
        => entity.hasAnimation && entity.hasAnimationTime; 

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.ReplaceAnimationTime(Time.time);
        }
    }
}