using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulateMatch
{
    public string mode;
    public int goalsToWin;
    public int timeToEnd;

    private const float Q = 1.7f;

    SimulateMatch(string mode, int goalsToWinOrTimeToEnd)
    {
        this.mode = mode;
        if(mode == "Goals")
            goalsToWin = goalsToWinOrTimeToEnd;
        else
            timeToEnd = goalsToWinOrTimeToEnd;
    }

    (int, int) simulate(int difficultA, int difficultB)
    {
        int goalsA = 0, goalsB = 0;

        if(mode == "Goals")
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

        if(mode == "Time and golden goal" && goalsA == goalsB)
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
