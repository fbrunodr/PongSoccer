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
    string chosenMode;
    string chosenDuration;

    void Start()
    {
        modes = new List<GameObject>(GameObject.FindGameObjectsWithTag("choiceObj"));
        durations = new List<GameObject>(GameObject.FindGameObjectsWithTag("choiceObj2"));
        selectMode(WinCondition.GetInstance().mode);
        if(chosenMode == "Goals")
        {
            int goalsToWin = WinCondition.GetInstance().goalsToWin;
            if(goalsToWin == 2)
                selectDuration("Short");
            else if(goalsToWin == 3)
                selectDuration("Medium");
            else if(goalsToWin == 5)
                selectDuration("Long");
        }
        else
        {
            int timeToEnd = WinCondition.GetInstance().timeToEnd;
            if(timeToEnd == 60)
                selectDuration("Short");
            else if(timeToEnd == 120)
                selectDuration("Medium");
            else if(timeToEnd == 180)
                selectDuration("Long");
        }
    }

    public void selectMode(string mode)
    {
        if(mode == null)
            return;
        if(chosenMode != null && mode == chosenMode)
            return;

        chosenMode = mode;

        //Debug.Log("Here Mode");

        if(mode == "Goals")
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
            if(modeObj.name != mode)
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
        WinCondition.GetInstance().mode = chosenMode;
        if(chosenMode == "Goals")
        {
            if(chosenDuration == "Short")
                WinCondition.GetInstance().goalsToWin = 2;
            else if(chosenDuration == "Medium")
                WinCondition.GetInstance().goalsToWin = 3;
            else if(chosenDuration == "Long")
                WinCondition.GetInstance().goalsToWin = 5;
        }
        else
        {
            if(chosenDuration == "Short")
                WinCondition.GetInstance().timeToEnd = 60;
            else if(chosenDuration == "Medium")
                WinCondition.GetInstance().timeToEnd = 120;
            else if(chosenDuration == "Long")
                WinCondition.GetInstance().timeToEnd = 180;
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
