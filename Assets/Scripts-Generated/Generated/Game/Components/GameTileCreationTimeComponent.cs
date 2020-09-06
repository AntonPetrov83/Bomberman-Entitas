//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TileCreationTimeComponent tileCreationTime { get { return (TileCreationTimeComponent)GetComponent(GameComponentsLookup.TileCreationTime); } }
    public bool hasTileCreationTime { get { return HasComponent(GameComponentsLookup.TileCreationTime); } }

    public void AddTileCreationTime(float newValue) {
        var index = GameComponentsLookup.TileCreationTime;
        var component = (TileCreationTimeComponent)CreateComponent(index, typeof(TileCreationTimeComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTileCreationTime(float newValue) {
        var index = GameComponentsLookup.TileCreationTime;
        var component = (TileCreationTimeComponent)CreateComponent(index, typeof(TileCreationTimeComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTileCreationTime() {
        RemoveComponent(GameComponentsLookup.TileCreationTime);
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

    static Entitas.IMatcher<GameEntity> _matcherTileCreationTime;

    public static Entitas.IMatcher<GameEntity> TileCreationTime {
        get {
            if (_matcherTileCreationTime == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TileCreationTime);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTileCreationTime = matcher;
            }

            return _matcherTileCreationTime;
        }
    }
}