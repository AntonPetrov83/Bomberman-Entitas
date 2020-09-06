using UnityEngine;
using UnityEngine.Tilemaps;

/**
 *
 * GameControllerBehaviour is the entry point to Match One
 *
 * The only purpose of this class is to redirect and forward
 * the Unity lifecycle events to the GameController
 *
 */

public class GameControllerBehaviour : MonoBehaviour
{
    [SerializeField] private Resources _resources;
    [SerializeField] private LevelDatabase _levelDatabase;
    [SerializeField] private Tilemap _tilemap;

    GameController _gameController;
    
    void Awake() => _gameController = new GameController(Contexts.sharedInstance, _resources, _levelDatabase, _tilemap);
    void Start() => _gameController.Initialize();
    void Update() => _gameController.Execute();
}