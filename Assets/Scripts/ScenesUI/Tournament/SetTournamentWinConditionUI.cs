using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TournamentNamespace;
using WinConditionNamespace;

public class SetTournamentWinConditionUI : MonoBehaviour
{

    List<GameObject> modes;
    List<GameObject> durations;

    void Start()
    {
        modes = new List<GameObject>(GameObject.FindGameObjectsWithTag("choiceObj"));
        durations = new List<GameObject>(GameObject.FindGameObjectsWithTag("choiceObj2"));
        WinCondition.Mode mode = TournamentManager.GetInstance().mode;
        selectMode(mode);
        if(mode == WinCondition.Mode.Goals)
        {
            int goalsToWin = TournamentManager.GetInstance().goalsToWin;
            if(goalsToWin == 2)
                selectDuration("Short");
            else if(goalsToWin == 3)
                selectDuration("Medium");
            else if(goalsToWin == 5)
                selectDuration("Long");
        }
        else
        {
            int timeToEnd = TournamentManager.GetInstance().timeToEnd;
            if(timeToEnd == 60)
                selectDuration("Short");
            else if(timeToEnd == 120)
                selectDuration("Medium");
            else if(timeToEnd == 180)
                selectDuration("Long");
        }
    }

    public void selectMode(WinCondition.Mode mode)
    {
        TournamentManager.GetInstance().mode = mode;

        //Debug.Log("Here Mode");

        if(mode == WinCondition.Mode.Goals)
        {
            foreach(GameObject duration in durations)
            {
                if(duration.name == "Short")
                    duration.transform.GetChild(1).GetComponent<Text>().text = "2 Goals";
                else if(duration.name == "Medium")
                    duration.transform.GetChild(1).GetComponent<Text>().text = "3 Goals";
                else if(duration.name == "Long")
                    duration.transform.GetChild(1).GetComponent<Text>().text = "5 Goals";
            }
        }
        else
        {
            foreach(GameObject duration in durations)
            {
                if(duration.name == "Short")
                    duration.transform.GetChild(1).GetComponent<Text>().text = "1 min";
                else if(duration.name == "Medium")
                    duration.transform.GetChild(1).GetComponent<Text>().text = "2 min";
                else if(duration.name == "Long")
                    duration.transform.GetChild(1).GetComponent<Text>().text = "3 min";
            }
        }

        foreach(GameObject modeObj in modes)
        {
            if(modeObj.name != WinCondition.modeToString(mode))
                modeObj.GetComponent<Toggle>().isOn = false;
            else
                modeObj.GetComponent<Toggle>().isOn = true;
        }
    }

    public void selectDuration(string duration)
    {
        if(duration == null)
            return;
            
        // we change both in case the player changes the
        // mode after (ex.: from time to goals)
        // and don't click on duration again
        if(duration == "Short")
        {
            TournamentManager.GetInstance().goalsToWin = 2;
            TournamentManager.GetInstance().timeToEnd = 60;
        }
        else if(duration == "Medium")
        {
            TournamentManager.GetInstance().goalsToWin = 3;
            TournamentManager.GetInstance().timeToEnd = 120;
        }
        else if(duration == "Long")
        {
            TournamentManager.GetInstance().goalsToWin = 5;
            TournamentManager.GetInstance().timeToEnd = 180;
        }

        //Debug.Log("Here Duration");

        foreach(GameObject durationObj in durations)
        {
            if(durationObj.name != duration)
                durationObj.GetComponent<Toggle>().isOn = false;
            else
                durationObj.GetComponent<Toggle>().isOn = true;
        }
    }

    public void gotoChooseTeam()
    {
        SceneManager.LoadScene("Assets/Scenes/PlayMenu/Tournament/ChooseTeam.unity");
    }

    public void gotoChooseField()
    {
        SceneManager.LoadScene("Assets/Scenes/PlayMenu/Tournament/ChooseField.unity");
    }
    
}
