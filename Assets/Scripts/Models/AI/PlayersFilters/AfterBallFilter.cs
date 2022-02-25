using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class AfterBallFilter : PlayersFilter
{
    private List<GameObject> players;
    private GameObject ball;
    
    public AfterBallFilter(List<GameObject> players, GameObject ball)
    {
        this.players = players;
        this.ball = ball;
    }

    public override List<GameObject> filter()
    {
        BeforeBallFilter beforeBallFilter = new BeforeBallFilter(players, ball);
        List<GameObject> complement = beforeBallFilter.filter();
        List<GameObject> filtredPlayers = players.Except(complement).ToList();
        return filtredPlayers;
    }
}
}