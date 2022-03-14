namespace WinConditionNamespace{
class WinConditionManager
{
    public WinCondition.Mode mode;
    public int goalsToWin;
    public int timeToEnd;

    private WinConditionManager()
    {
        mode = WinCondition.Mode.Time;
        goalsToWin = 3;
        timeToEnd = 60;
    }

    private static WinConditionManager _instance;

    private static readonly object _lock = new object();

    public static WinConditionManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new WinConditionManager();
                }
            }
        }
        return _instance;
    }
}
}