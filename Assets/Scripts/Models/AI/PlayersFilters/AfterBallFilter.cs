using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class AfterBallFilter : PlayersFilter
{
    public AfterBallFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball) : base(players, oponents, ball){}

    public override List<GameObject> filter()
    {
        BeforeBallFilter beforeBallFilter = new BeforeBallFilter(players, oponents, ball);
        List<GameObject> complement = beforeBallFilter.filter();
        List<GameObject> filtredPlayers = players.Except(complement).ToList();
        return filtredPlayers;
    }
}
}