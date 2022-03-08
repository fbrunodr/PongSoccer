using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TeamNamespace;
using TournamentNamespace;

public class ChooseTournamentTeamUI : MonoBehaviour
{
    List<GameObject> teams;

    // Start is called before the first frame update
    void Start()
    {
        teams = new List<GameObject>(GameObject.FindGameObjectsWithTag("choiceObj"));
        selectTournamentTeam(TournamentManager.GetInstance().playerTeam);
    }

    public void selectTournamentTeam(Team team)
    {
        if(team == null)
            return;

        TournamentManager.GetInstance().playerTeam = team;

        foreach(GameObject teamObj in teams)
        {
            if(teamObj.name == team.getName())
                teamObj.transform.GetChild(1).GetComponent<Text>().color = Color.red;
            else
                teamObj.transform.GetChild(1).GetComponent<Text>().color = Color.white;
        }
    }

    public void gotoSelectWinCondition()
    {
        SceneManager.LoadScene("Assets/Scenes/PlayMenu/Tournament/SetWinCondition.unity");
    }

    public void gotoCreateTournament()
    {
        SceneManager.LoadScene("Assets/Scenes/PlayMenu/Tournament/CreateTournament.unity");
    }
}
