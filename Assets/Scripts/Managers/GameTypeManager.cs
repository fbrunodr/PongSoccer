namespace GameTypeNamespace
{

public enum GameType
{
    QuickMatch,
    Tournament,
    League
}

public class GameTypeManager
{

    public GameType type;

    private GameTypeManager()
    {
        type = GameType.QuickMatch;
    }

    private static GameTypeManager _instance;

    private static readonly object _lock = new object();

    public static GameTypeManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new GameTypeManager();
                }
            }
        }
        return _instance;
    }
}
}