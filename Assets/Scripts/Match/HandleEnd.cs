using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using WinConditionNamespace;

public class HandleEnd : MonoBehaviour
{

    string mode;
    GoalHandler goalHandler;
    TimeHandler timeHandler;

    GameObject endGamePanel;
    Button continueButton;

    // Start is called before the first frame update
    void Start()
    {
        endGamePanel = GameObject.Find("EndGamePanel");
        continueButton = endGamePanel.transform.Find("Continue").gameObject.GetComponent<Button>();
        endGamePanel.SetActive(false);
        Time.timeScale = 1;
        mode = WinCondition.GetInstance().mode;
        goalHandler = GameObject.Find("Game").GetComponent<GoalHandler>();
        timeHandler = GameObject.Find("Game").GetComponent<TimeHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == "Time" && timeHandler.getSeconds() < 0)
        {
            int goalDiff = goalHandler.getHomeGoals() - goalHandler.getAwayGoals();
            end(goalDiff);
        }
        else if(mode == "Time and golden goal" && timeHandler.getSeconds() < 0)
        {
            int goalDiff = goalHandler.getHomeGoals() - goalHandler.getAwayGoals();
            if(goalDiff != 0)
                end(goalDiff);
        }
        else if(mode == "Goal")
        {
            int homeGoals = goalHandler.getHomeGoals();
            int awayGoals = goalHandler.getAwayGoals();
            int goalsToWin = WinCondition.GetInstance().goalsToWin;
            if(homeGoals == goalsToWin || awayGoals == goalsToWin)
            {
                int goalDiff = homeGoals - awayGoals;
                end(goalDiff);
            }
        }
        
    }

    void end(int goalDiff)
    {
        Time.timeScale = 0;
        endGamePanel.SetActive(true);
        Text endGameText = endGamePanel.transform.Find("EndGameText").gameObject.GetComponent<Text>();
        if(goalDiff > 0)
            endGameText.text = "You Won!!";
        else if(goalDiff < 0)
            endGameText.text = "You Lost";
        else
            endGameText.text = "Draw";
        continueButton.onClick.AddListener(finish);
    }

    void finish()
    {
        //continueButton.interactable = false;
        continueButton.onClick.RemoveListener(finish);
        SceneManager.LoadSceneAsync("MainMenu");
        SceneManager.UnloadSceneAsync("StandardMatch");
    }
}
