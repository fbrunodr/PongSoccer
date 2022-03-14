using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WinConditionNamespace;

public class SimulateMatch
{
    public WinCondition.Mode mode;
    public int goalsToWin;
    public int timeToEnd;

    private const float Q = 1.7f;

    SimulateMatch(WinCondition.Mode mode, int goalsToWinOrTimeToEnd)
    {
        this.mode = mode;
        if(mode == WinCondition.Mode.Goals)
            goalsToWin = goalsToWinOrTimeToEnd;
        else
            timeToEnd = goalsToWinOrTimeToEnd;
    }

    (int, int) simulate(int difficultA, int difficultB)
    {
        int goalsA = 0, goalsB = 0;

        if(mode == WinCondition.Mode.Goals)
        {
            while(goalsA < goalsToWin && goalsB < goalsToWin)
            {
                if(didFirstTeamScored(difficultA, difficultB))
                    goalsA++;
                else
                    goalsB++;
            }
        }
        else
        {
            int goalsToEnd = chooseGoalAmount();
            while(goalsA + goalsB < goalsToEnd)
            {
                if(didFirstTeamScored(difficultA, difficultB))
                    goalsA++;
                else
                    goalsB++;
            }
        }

        if(mode == WinCondition.Mode.TimeAndGoldenGoal && goalsA == goalsB)
        {
            if(didFirstTeamScored(difficultA, difficultB))
                goalsA++;
            else
                goalsB++;
        }

        return (goalsA, goalsB);
    }

    int chooseGoalAmount()
    {
        return Random.Range(0, (int)timeToEnd/30 + 1) + Random.Range(0, 2) + 2*Random.Range(0,2);
    }

    bool didFirstTeamScored(int difficultA, int difficultB)    
    {
        float aRange = Mathf.Pow(Q, difficultA);
        float bRange = Mathf.Pow(Q, difficultB);
        float totalRange = aRange + bRange;
        return Random.Range(0,totalRange) < aRange;
    }
}
