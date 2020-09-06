using System.Collections.Generic;
using Entitas;

public sealed class UpdateSpriteSystem : ReactiveSystem<GameEntity>
{
    public UpdateSpriteSystem(Contexts contexts) : base(contexts.game)
    { }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.AllOf(GameMatcher.Sprite, GameMatcher.View));

    protected override bool Filter(GameEntity entity)
        => entity.hasSprite && entity.hasView;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.view.value.SetSprite(e.sprite.value);
        }
    }
}