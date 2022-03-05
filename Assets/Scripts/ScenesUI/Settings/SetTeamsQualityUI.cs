using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DifficutiesNamespace;

public class SetTeamsQualityUI : MonoBehaviour
{

    List<GameObject> teams;

    // Start is called before the first frame update
    void Start()
    {
        teams = new List<GameObject>(GameObject.FindGameObjectsWithTag("awayTeam"));
        foreach(GameObject team in teams)
        {
            int stars = DifficutiesManager.GetInstance().difficulties[team.name];
            setTeamStars(team, stars);
        }
    }

    private void setTeamStars(GameObject team, int stars)
    {
        Transform starsTransform = team.transform.GetChild(2);
        foreach(Transform child in starsTransform)
        {
            if(child.name.Contains("Button"))
                continue;
            int childStars = int.Parse(child.name[0].ToString());
            if(childStars <= stars)
                child.gameObject.GetComponent<Toggle>().isOn = true;
            else
                child.gameObject.GetComponent<Toggle>().isOn = false;
        }
    }

    private int getTeamStars(GameObject team)
    {
        int maxStars = 1;
        Transform starsTransform = team.transform.GetChild(2);
        foreach(Transform child in starsTransform)
        {
            if(child.name.Contains("Button"))
                continue;
            if(child.gameObject.GetComponent<Toggle>().isOn)
            {
                int childStars = int.Parse(child.name[0].ToString());
                maxStars = Mathf.Max(maxStars, childStars);
            }
        }
        return maxStars;
    }

    public void resetTeamsStars()
    {
        foreach(GameObject team in teams)
        {
            int stars = DifficutiesManager.GetInstance().standardDifficulties[team.name];
            setTeamStars(team, stars);
        }
    }

    public void save()
    {
        Dictionary<string, int> difficulties = new Dictionary<string, int>();
        foreach(GameObject teamObj in teams)
        {
            string teamName = teamObj.name;
            int difficult = getTeamStars(teamObj);
            difficulties.Add(teamName, difficult);
        }
        DifficutiesManager.GetInstance().difficulties = difficulties;
        DifficutiesManager.GetInstance().saveTeamsData();
    }

    public void gotoSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
