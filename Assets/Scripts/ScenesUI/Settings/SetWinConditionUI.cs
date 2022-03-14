using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using WinConditionNamespace;

public class SetWinConditionUI : MonoBehaviour
{

    List<GameObject> modes;
    List<GameObject> durations;
    WinCondition.Mode chosenMode;
    string chosenDuration;

    void Start()
    {
        modes = new List<GameObject>(GameObject.FindGameObjectsWithTag("choiceObj"));
        durations = new List<GameObject>(GameObject.FindGameObjectsWithTag("choiceObj2"));
        selectMode(WinConditionManager.GetInstance().mode);
        if(chosenMode == WinCondition.Mode.Goals)
        {
            int goalsToWin = WinConditionManager.GetInstance().goalsToWin;
            if(goalsToWin == 2)
                selectDuration("Short");
            else if(goalsToWin == 3)
                selectDuration("Medium");
            else if(goalsToWin == 5)
                selectDuration("Long");
        }
        else
        {
            int timeToEnd = WinConditionManager.GetInstance().timeToEnd;
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
        chosenMode = mode;

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
        if(chosenDuration != null && duration == chosenDuration)
            return;
            
        chosenDuration = duration;

        //Debug.Log("Here Duration");

        foreach(GameObject durationObj in durations)
        {
            if(durationObj.name != duration)
                durationObj.GetComponent<Toggle>().isOn = false;
            else
                durationObj.GetComponent<Toggle>().isOn = true;
        }
    }

    public void save()
    {
        WinConditionManager.GetInstance().mode = chosenMode;
        if(chosenMode == WinCondition.Mode.Goals)
        {
            if(chosenDuration == "Short")
                WinConditionManager.GetInstance().goalsToWin = 2;
            else if(chosenDuration == "Medium")
                WinConditionManager.GetInstance().goalsToWin = 3;
            else if(chosenDuration == "Long")
                WinConditionManager.GetInstance().goalsToWin = 5;
        }
        else
        {
            if(chosenDuration == "Short")
                WinConditionManager.GetInstance().timeToEnd = 60;
            else if(chosenDuration == "Medium")
                WinConditionManager.GetInstance().timeToEnd = 120;
            else if(chosenDuration == "Long")
                WinConditionManager.GetInstance().timeToEnd = 180;
        }

        SceneManager.UnloadSceneAsync("SetWinCondition");
        makeSettingsIteractiveAgain();
    }

    public void cancel()
    {
        SceneManager.UnloadSceneAsync("SetWinCondition") ;
        makeSettingsIteractiveAgain();
    }

    private void makeSettingsIteractiveAgain()
    {
        GameObject.Find("Canvas").GetComponent<SettingsUI>().enableSystemsBack();
    }
}
