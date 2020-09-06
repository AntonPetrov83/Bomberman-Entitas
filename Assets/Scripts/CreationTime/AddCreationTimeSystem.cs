using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddCreationTimeSystem : ReactiveSystem<GameEntity>
{
    public AddCreationTimeSystem(Contexts contexts) : base(contexts.game)
    { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Animation);

    protected override bool Filter(GameEntity entity)
        => !entity.hasCreationTime; 

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.AddCreationTime(Time.time);
        }
    }
}