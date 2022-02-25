using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class FarFromBallFilter : PlayersFilter
{
    private List<GameObject> players;
    private GameObject ball;
    
    public FarFromBallFilter(List<GameObject> players, GameObject ball)
    {
        this.players = players;
        this.ball = ball;
    }

    public override List<GameObject> filter()
    {
        float DISTANCE_THRESHOLD = 30;
        Vector3 ballPos = ball.transform.position;
        ballPos.y = 0;
        
        List<GameObject> filtredPlayers = new List<GameObject>();
        foreach(GameObject player in players)
        {
            Vector3 playerPosition = player.transform.position;
            playerPosition.y = 0;  
            float distanceFromBall = (playerPosition - ballPos).magnitude;
            if(distanceFromBall > DISTANCE_THRESHOLD)
                filtredPlayers.Add(player);
        }

        return filtredPlayers;
    }
}
}