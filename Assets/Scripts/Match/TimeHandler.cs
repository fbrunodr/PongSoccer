using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WinConditionNamespace;
using GameTypeNamespace;
using TournamentNamespace;

public class TimeHandler : MonoBehaviour
{

    private float seconds;
    private bool decrementing;
    private float referenceTime;

    // Start is called before the first frame update
    void Start()
    {
        WinCondition.Mode mode = WinCondition.Mode.Time;

        GameType gameType = GameTypeManager.GetInstance().type;
        if(gameType == GameType.QuickMatch)
            mode = WinConditionManager.GetInstance().mode;
        else if(gameType == GameType.Tournament)
            mode = TournamentManager.GetInstance().mode;

        if(mode == WinCondition.Mode.Time || mode == WinCondition.Mode.TimeAndGoldenGoal)
        {
            decrementing = true;
            if(gameType == GameType.QuickMatch)
                seconds = WinConditionManager.GetInstance().timeToEnd;
            else if(gameType == GameType.Tournament)
                seconds = TournamentManager.GetInstance().timeToEnd;
            referenceTime = Time.time + seconds;
        }
        else
        {
            decrementing = false;
            seconds = 0;
            referenceTime = Time.time;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(decrementing)
        {
            seconds = referenceTime - Time.time;
        }
        else
        {
            seconds = Time.time - referenceTime;
        }
    }

    public float getSeconds()
    {
        return seconds;
    }
}
