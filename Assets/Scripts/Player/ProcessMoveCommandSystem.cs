using System.Collections.Generic;
using Animation;
using Entitas;
using UnityEngine;
using UnityEngine.EventSystems;

public sealed class ProcessMoveCommandSystem : ReactiveSystem<GameEntity>
{
    private IResources _resources;
    
    public ProcessMoveCommandSystem(Contexts contexts) : base(contexts.game)
    {
        _resources = contexts.config.resources.value;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.MoveCommand);

    protected override bool Filter(GameEntity entity)
        => entity.hasMoveCommand;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            if (!e.hasMoveCommand)
            {
                e.RemoveVelocity();
                continue;
            }

            var newVelocity = GetVelocity(e.moveCommand.value);
            if (!e.hasVelocity || e.velocity.value != newVelocity)
                e.ReplaceVelocity(newVelocity);

            var newAnimation = GetAnimation(newVelocity);
            if (newAnimation == null)
            {
                if (e.hasAnimationTime)
                {
                    e.RemoveAnimationTime();
                }
            }
            else
            {
                if (!e.hasAnimation || e.animation.value != newAnimation || !e.hasAnimationTime)
                {
                    e.ReplaceAnimation(newAnimation);
                    e.ReplaceAnimationTime(Time.time);
                }
            }
        }
    }

    private Vector2 GetVelocity(MoveDirections directions)
    {
        var result = Vector2.zero;

        var speed = PlayerState.sharedInstance.hasSpeedup ? 4 : 3;

        if (directions.HasFlag(MoveDirections.Left))
            result.x = -speed;
        else if (directions.HasFlag(MoveDirections.Right))
            result.x = speed;

        if (directions.HasFlag(MoveDirections.Up))
            result.y = -speed;
        else if (directions.HasFlag(MoveDirections.Down))
            result.y = speed;
        
        return result;
    }

    private AnimationDefinition GetAnimation(Vector2 velocity)
    {
        if (velocity.x < 0)
            return _resources.bombermanLeft;
        
        if (velocity.x > 0)
            return _resources.bombermanRight;
        
        if (velocity.y < 0)
            return _resources.bombermanUp;

        if (velocity.y > 0)
            return _resources.bombermanDown;
        
        return null;
    }
}