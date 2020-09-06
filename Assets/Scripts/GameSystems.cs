public sealed class GameSystems : Feature
{
    public GameSystems(Contexts contexts)
    {
        Add(new BoardCreateSystem(contexts));
        Add(new StartGameSystem(contexts));

        // Utilities.
        Add(new AddCreationTimeSystem(contexts));
        Add(new AddViewSystem(contexts));
        Add(new UpdateAnimationTimeSystem(contexts));
        Add(new UpdateAnimationSystem(contexts));
        Add(new UpdateSpriteSystem(contexts));
        Add(new SetTileSystem(contexts));
        Add(new AddTileCreationTimeSystem(contexts));
        Add(new UpdateTileAnimationSystem(contexts));
        
        // Input
        Add(new InputSystem(contexts));
        
        // Player
        Add(new ProcessDetonateCommandSystem(contexts));
        Add(new ProcessBombCommandSystem(contexts));
        Add(new ProcessMoveCommandSystem(contexts));
        Add(new PlayerMovementSystem(contexts));
        Add(new TakePowerupsSystem(contexts));
        Add(new ProcessPlayerKilledSystem(contexts));
        Add(new PlayerKillByEnemySystem(contexts));
        Add(new KillByExplosionSystem(contexts));
        Add(new ProcessEnemyKilledSystem(contexts));
        Add(new BallomMovementSystem(contexts));
        Add(new DoorExitSystem(contexts));
        Add(new BombTimerSystem(contexts));
        Add(new BombExplosionSystem(contexts));
        Add(new BrickWallExplosionSystem(contexts));
        Add(new FireSystem(contexts));

        // Camera (after the player).
        Add(new CameraSystem(contexts));
        
        // Events (Generated)
        Add(new GameEventSystems(contexts));

        // Cleanup
        Add(new DestroyDestroyedSystem(contexts));
    }
}