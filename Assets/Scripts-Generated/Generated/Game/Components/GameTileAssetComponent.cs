//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public TileAssetComponent tileAsset { get { return (TileAssetComponent)GetComponent(GameComponentsLookup.TileAsset); } }
    public bool hasTileAsset { get { return HasComponent(GameComponentsLookup.TileAsset); } }

    public void AddTileAsset(UnityEngine.Tilemaps.Tile newValue) {
        var index = GameComponentsLookup.TileAsset;
        var component = (TileAssetComponent)CreateComponent(index, typeof(TileAssetComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceTileAsset(UnityEngine.Tilemaps.Tile newValue) {
        var index = GameComponentsLookup.TileAsset;
        var component = (TileAssetComponent)CreateComponent(index, typeof(TileAssetComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveTileAsset() {
        RemoveComponent(GameComponentsLookup.TileAsset);
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

    static Entitas.IMatcher<GameEntity> _matcherTileAsset;

    public static Entitas.IMatcher<GameEntity> TileAsset {
        get {
            if (_matcherTileAsset == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.TileAsset);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherTileAsset = matcher;
            }

            return _matcherTileAsset;
        }
    }
}
