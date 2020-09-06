//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class TilemapPositionEventSystem : Entitas.ReactiveSystem<GameEntity> {

    readonly System.Collections.Generic.List<ITilemapPositionListener> _listenerBuffer;

    public TilemapPositionEventSystem(Contexts contexts) : base(contexts.game) {
        _listenerBuffer = new System.Collections.Generic.List<ITilemapPositionListener>();
    }

    protected override Entitas.ICollector<GameEntity> GetTrigger(Entitas.IContext<GameEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(GameMatcher.TilemapPosition)
        );
    }

    protected override bool Filter(GameEntity entity) {
        return entity.hasTilemapPosition && entity.hasTilemapPositionListener;
    }

    protected override void Execute(System.Collections.Generic.List<GameEntity> entities) {
        foreach (var e in entities) {
            var component = e.tilemapPosition;
            _listenerBuffer.Clear();
            _listenerBuffer.AddRange(e.tilemapPositionListener.value);
            foreach (var listener in _listenerBuffer) {
                listener.OnTilemapPosition(e, component.value);
            }
        }
    }
}
