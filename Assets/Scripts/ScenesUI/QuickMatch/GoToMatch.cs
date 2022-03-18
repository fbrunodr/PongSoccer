using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TeamNamespace;
using GameTypeNamespace;

public class GoToMatch : MonoBehaviour
{
    public void gotoMatch()
    {
        Team homeTeam = GameObject.Find("Canvas").GetComponent<ChooseTeams>().getHomeTeam();
        Team awayTeam = GameObject.Find("Canvas").GetComponent<ChooseTeams>().getAwayTeam();

        if(homeTeam == null || awayTeam == null)
            return;

        TeamManager.GetInstance().homeTeam = homeTeam;
        TeamManager.GetInstance().awayTeam = awayTeam;
        
        GameTypeManager.GetInstance().type = GameType.QuickMatch;
        SceneManager.LoadScene("StandardMatch");
    }
}
