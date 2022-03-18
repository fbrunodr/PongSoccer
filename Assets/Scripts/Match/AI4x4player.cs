using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AInamespace;
using DifficutiesNamespace;
using TeamNamespace;
using GameTypeNamespace;
using TournamentNamespace;

public class AI4x4player : MonoBehaviour
{

    AI4x4 ai;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> players = new List<GameObject>();
        for(int i = 0; i < 4; i++)
        {
            GameObject player = GameObject.Find("Away" + i.ToString()).transform.Find("Body").gameObject;
            if(player == null)
                break;
            players.Add(player);
        }

        List<GameObject> oponents = new List<GameObject>();
        for(int i = 0; i < 4; i++)
        {
            GameObject oponent = GameObject.Find("Home" + i.ToString()).transform.Find("Body").gameObject;
            if(oponent == null)
                break;
            oponents.Add(oponent);
        }

        GameObject ball = GameObject.Find("Ball");

        string aiTeamName = ""; 

        GameType gameType = GameTypeManager.GetInstance().type;
        if(gameType == GameType.QuickMatch)
            aiTeamName = TeamManager.GetInstance().awayTeam.getName();
        else if(gameType == GameType.Tournament)
            aiTeamName = TournamentManager.GetInstance().oponent.getName();

        int aiTeamDifficult = DifficutiesManager.GetInstance().difficulties[aiTeamName];
        
        ai = new AI4x4(players, oponents, ball, aiTeamDifficult);
    }

    // Update is called once per frame
    void Update()
    {
        ai.play();        
    }
}
