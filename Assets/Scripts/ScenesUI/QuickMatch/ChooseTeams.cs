using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TeamNamespace;

public class ChooseTeams : MonoBehaviour
{
    List<GameObject> homeTeams;
    List<GameObject> awayTeams;

    private Team chosenHomeTeam;
    private Team chosenAwayTeam;

    // Start is called before the first frame update
    void Start()
    {
        homeTeams = new List<GameObject>(GameObject.FindGameObjectsWithTag("homeTeam"));
        awayTeams = new List<GameObject>(GameObject.FindGameObjectsWithTag("awayTeam"));
        selectHomeTeam(TeamManager.GetInstance().homeTeam);
        selectAwayTeam(TeamManager.GetInstance().awayTeam);
    }

    public void selectHomeTeam(Team team)
    {
        if(team == null)
            return;
        if(chosenHomeTeam != null && chosenHomeTeam.Equals(team))
            return;
        if(chosenAwayTeam != null && chosenAwayTeam.Equals(team))
            return;

        foreach(GameObject homeTeam in homeTeams)
        {
            if(homeTeam.name != team.getName())
                homeTeam.transform.GetChild(1).GetComponent<Text>().color = Color.white;
            else
                homeTeam.transform.GetChild(1).GetComponent<Text>().color = Color.red;
        }
        chosenHomeTeam = team;
    }

    public void selectAwayTeam(Team team)
    {
        if(team == null)
            return;
        if(chosenAwayTeam != null && chosenAwayTeam.Equals(team))
            return;
        if(chosenHomeTeam != null && chosenHomeTeam.Equals(team))
            return;

        foreach(GameObject awayTeam in awayTeams)
        {
            if(awayTeam.name != team.getName())
                awayTeam.transform.GetChild(1).GetComponent<Text>().color = Color.white;
            else
                awayTeam.transform.GetChild(1).GetComponent<Text>().color = Color.red;
        }
        chosenAwayTeam = team;
    }
    

    public Team getHomeTeam()
    {
        return chosenHomeTeam;
    }

    public Team getAwayTeam()
    {
        return chosenAwayTeam;
    }
}
