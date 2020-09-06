using Entitas;

public class KillByExplosionSystem : IExecuteSystem
{
    private IGroup<GameEntity> _exploded;
    private IGroup<GameEntity> _creatures;
    
    public KillByExplosionSystem(Contexts contexts)
    {
        _exploded = contexts.game.GetGroup(GameMatcher.Exploded);
        _creatures = contexts.game.GetGroup(GameMatcher.AnyOf(GameMatcher.Player, GameMatcher.Enemy));
    }
    
    public void Execute()
    {
        foreach (var exploded in _exploded)
        {
            var explosionTilemapPosition = exploded.tilemapPosition.value;
            
            foreach (var creature in _creatures)
            {
                if (creature.isKilled)
                    continue;

                if (creature.tilemapPosition.value == explosionTilemapPosition)
                    creature.isKilled = true;
            }
        }
    }
}