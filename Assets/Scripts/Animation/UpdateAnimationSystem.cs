using Entitas;
using UnityEngine;

public sealed class UpdateAnimationSystem : IExecuteSystem
{
    private readonly IGroup<GameEntity> _entities;

    public UpdateAnimationSystem(Contexts contexts)
    {
        _entities = contexts.game.GetGroup(GameMatcher.Animation);
    }

    public void Execute()
    {
        var now = Time.time;
        
        foreach (var e in _entities)
        {
            if (!e.hasAnimation)
                continue;

            var animation = e.animation.value;
            
            if (e.hasAnimationTime)
            {
                var time = now - e.animationTime.value;
                
                var sprite = animation.GetSprite(time);

                if (!e.hasSprite || sprite != e.sprite.value)
                    e.ReplaceSprite(sprite);

                if (!animation.looped && time >= animation.length)
                {
                    if (e.isAutoDestroyedWhenAnimationEnds)
                        e.isDestroyed = true;
                }
            }
            else
            {
                // initialize sprite.
                if (!e.hasSprite)
                    e.ReplaceSprite(animation.GetSprite(0));
            }
        }
    }
}