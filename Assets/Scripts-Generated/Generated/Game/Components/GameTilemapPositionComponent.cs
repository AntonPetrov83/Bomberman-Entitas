//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TilemapPositionComponent tilemapPosition { get { return (TilemapPositionComponent)GetComponent(GameComponentsLookup.TilemapPosition); } }
    public bool hasTilemapPosition { get { return HasComponent(GameComponentsLookup.TilemapPosition); } }

    public void AddTilemapPosition(UnityEngine.Vector2Int newValue) {
        var index = GameComponentsLookup.TilemapPosition;
        var component = (TilemapPositionComponent)CreateComponent(index, typeof(TilemapPositionComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTilemapPosition(UnityEngine.Vector2Int newValue) {
        var index = GameComponentsLookup.TilemapPosition;
        var component = (TilemapPositionComponent)CreateComponent(index, typeof(TilemapPositionComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTilemapPosition() {
        RemoveComponent(GameComponentsLookup.TilemapPosition);
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherTilemapPosition;

    public static Entitas.IMatcher<GameEntity> TilemapPosition {
        get {
            if (_matcherTilemapPosition == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TilemapPosition);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTilemapPosition = matcher;
            }

            return _matcherTilemapPosition;
        }
    }
}