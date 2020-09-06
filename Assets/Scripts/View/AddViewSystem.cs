using System.Collections.Generic;
using Entitas;
using UnityEngine;

public sealed class AddViewSystem : ReactiveSystem<GameEntity>
{
    readonly Transform _parent;

    public AddViewSystem(Contexts contexts) : base(contexts.game)
    {
        _parent = new GameObject("Views").transform;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        => context.CreateCollector(GameMatcher.Sprite);

    protected override bool Filter(GameEntity entity) 
        => entity.hasSprite && !entity.hasView;

    protected override void Execute(List<GameEntity> entities)
    {
        foreach (var e in entities)
        {
            e.AddView(CreateView(e));
        }
    }

    IView CreateView(GameEntity entity)
    {
        var obj = new GameObject("View");
        obj.transform.parent = _parent;
        obj.AddComponent<SpriteRenderer>();
        var view = obj.AddComponent<View>();
        view.Link(entity);
        return view;
    }
}