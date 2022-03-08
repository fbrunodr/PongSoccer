using System.Collections;
using System.Collections.Generic;
using FieldNamespace;
using TeamNamespace;

namespace TournamentNamespace{
public class TournamentManager
{
    public Team playerTeam;
    public Field field;
    public string mode;
    public int goalsToWin;
    public int timeToEnd;

    private TournamentManager()
    {
        playerTeam = null;
        field = new Field("neighborhood_field");
        mode = "Time";
        goalsToWin = 2;
        timeToEnd = 60;
    }

    private static TournamentManager _instance;

    private static readonly object _lock = new object();

    public static TournamentManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new TournamentManager();
                }
            }
        }
        return _instance;
    }
}
}