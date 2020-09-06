public class PlayerState
{
    private static PlayerState _sharedInstance = new PlayerState();

    public static PlayerState sharedInstance => _sharedInstance;

    public int bombsAvailable = 5;

    public int bombRange = 1;

    public bool hasSpeedup = false;

    public bool hasDetonator = false;
}
