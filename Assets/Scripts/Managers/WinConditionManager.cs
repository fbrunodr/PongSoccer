namespace WinConditionNamespace{
class WinCondition
{
    public string mode;
    public int goalsToWin;
    public int timeToEnd;

    private WinCondition()
    {
        mode = "Time";
        goalsToWin = 3;
        timeToEnd = 60;
    }

    private static WinCondition _instance;

    private static readonly object _lock = new object();

    public static WinCondition GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new WinCondition();
                }
            }
        }
        return _instance;
    }
}
}