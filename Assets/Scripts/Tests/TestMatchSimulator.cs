using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AInamespace;
using WinConditionNamespace;
using TeamNamespace;

public class TestMatchSimulator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        SimulateMatch simulateMatch = new SimulateMatch(WinCondition.Mode.TimeAndGoldenGoal, 60);

        int diffA = 2;
        int diffB = 4;

        int total = 1000000;
        int winsA = 0, winsB = 0, draws = 0;

        for(int i = 0; i < total; i++)
        {
            (int goalsA, int goalsB) = simulateMatch.simulate(diffA, diffB);
            if(goalsA > goalsB)
                winsA++;
            else if(goalsB > goalsA)
                winsB++;
            else
                draws++;
        }

        Debug.Log("Team " + diffA.ToString() + " stars wins: " + (100*winsA/total).ToString() + "%");
        Debug.Log("Team " + diffB.ToString() + " stars wins: " + (100*winsB/total).ToString() + "%");
        Debug.Log("Draws: " + (100*draws/total).ToString() + "%");
    }

}
