//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public PowerupComponent powerup { get { return (PowerupComponent)GetComponent(GameComponentsLookup.Powerup); } }
    public bool hasPowerup { get { return HasComponent(GameComponentsLookup.Powerup); } }

    public void AddPowerup(PowerupType newValue) {
        var index = GameComponentsLookup.Powerup;
        var component = (PowerupComponent)CreateComponent(index, typeof(PowerupComponent));
        component.value = newValue;
        AddComponent(index, component);
    }

    public void ReplacePowerup(PowerupType newValue) {
        var index = GameComponentsLookup.Powerup;
        var component = (PowerupComponent)CreateComponent(index, typeof(PowerupComponent));
        component.value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemovePowerup() {
        RemoveComponent(GameComponentsLookup.Powerup);
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

    static Entitas.IMatcher<GameEntity> _matcherPowerup;

    public static Entitas.IMatcher<GameEntity> Powerup {
        get {
            if (_matcherPowerup == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.Powerup);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherPowerup = matcher;
            }

            return _matcherPowerup;
        }
    }
}
