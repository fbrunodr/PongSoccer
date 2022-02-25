using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class CloseToBallFilter : PlayersFilter
{
    private List<GameObject> players;
    private GameObject ball;
    
    public CloseToBallFilter(List<GameObject> players, GameObject ball)
    {
        this.players = players;
        this.ball = ball;
    }

    public override List<GameObject> filter()
    {
        FarFromBallFilter farFromBallFilter = new FarFromBallFilter(players, ball);
        List<GameObject> complement = farFromBallFilter.filter();
        List<GameObject> filtredPlayers = players.Except(complement).ToList();
        return filtredPlayers;
    }
}
}