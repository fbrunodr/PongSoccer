using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WinConditionNamespace;
using TeamNamespace;
using GameTypeNamespace;
using TournamentNamespace;

public class MatchUI : MonoBehaviour
{

    GoalHandler goalHandler;
    TimeHandler timeHandler;
    Text score;
    Text timer;

    // Start is called before the first frame update
    void Start()
    {
        goalHandler = GameObject.Find("Game").GetComponent<GoalHandler>();
        timeHandler = GameObject.Find("Game").GetComponent<TimeHandler>();
        score = GameObject.Find("Score").GetComponent<Text>();
        timer = GameObject.Find("Time").GetComponent<Text>();

        string homeImagePath = "";
        string awayImagePath = "";
        
        GameType gameType = GameTypeManager.GetInstance().type;
        if(gameType == GameType.QuickMatch)
        {
            homeImagePath = TeamManager.GetInstance().homeTeam.getImagePath();
            awayImagePath = TeamManager.GetInstance().awayTeam.getImagePath();
        }
        else if(gameType == GameType.Tournament)
        {
            homeImagePath = TournamentManager.GetInstance().playerTeam.getImagePath();
            awayImagePath = TournamentManager.GetInstance().oponent.getImagePath();
        }

        Sprite homeImage = Resources.Load<Sprite>(homeImagePath);
        Sprite awayImage = Resources.Load<Sprite>(awayImagePath);
        GameObject.Find("HomeTeam").GetComponent<Image>().sprite = homeImage;
        GameObject.Find("AwayTeam").GetComponent<Image>().sprite = awayImage;
    }

    // Update is called once per frame
    void Update()
    {
        updateScore();
        updateTimer();
    }

    void updateScore()
    {
        score.text = goalHandler.getHomeGoals().ToString() + " - " + goalHandler.getAwayGoals().ToString();
    }

    void updateTimer()
    {
        int seconds = (int)timeHandler.getSeconds();
        if(timeHandler.getSeconds() < 0 && WinConditionManager.GetInstance().mode == WinCondition.Mode.TimeAndGoldenGoal)
        {
            seconds *= -1;
            Color newColor = Color.yellow;
            timer.color = newColor;
        }
        int minutes = seconds/60;
        seconds %= 60;
        timer.text = string.Format("{0,1:0}:{1,2:00}", minutes, seconds);
    }
}
