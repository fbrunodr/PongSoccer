using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using WinConditionNamespace;

public class HandleEnd : MonoBehaviour
{

    WinCondition.Mode mode;
    GoalHandler goalHandler;
    TimeHandler timeHandler;

    GameObject endGamePanel;

    // Start is called before the first frame update
    void Start()
    {
        endGamePanel = GameObject.Find("EndGamePanel");
        endGamePanel.SetActive(false);
        Time.timeScale = 1;
        mode = WinConditionManager.GetInstance().mode;
        goalHandler = GameObject.Find("Game").GetComponent<GoalHandler>();
        timeHandler = GameObject.Find("Game").GetComponent<TimeHandler>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mode == WinCondition.Mode.Time && timeHandler.getSeconds() < 0)
        {
            int goalDiff = goalHandler.getHomeGoals() - goalHandler.getAwayGoals();
            end(goalDiff);
        }
        else if(mode == WinCondition.Mode.TimeAndGoldenGoal && timeHandler.getSeconds() < 0)
        {
            int goalDiff = goalHandler.getHomeGoals() - goalHandler.getAwayGoals();
            if(goalDiff != 0)
                end(goalDiff);
        }
        else if(mode == WinCondition.Mode.Goals)
        {
            int homeGoals = goalHandler.getHomeGoals();
            int awayGoals = goalHandler.getAwayGoals();
            int goalsToWin = WinConditionManager.GetInstance().goalsToWin;
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
    }
}
