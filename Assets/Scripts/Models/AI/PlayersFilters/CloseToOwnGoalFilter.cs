using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class CloseToOwnGoalFilter : PlayersFilter
{
    public CloseToOwnGoalFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball) : base(players, oponents, ball){}

    public override List<GameObject> filter()
    {
        FarFromOwnGoalFilter farFromOwnGoalFilter = new FarFromOwnGoalFilter(players, oponents, ball);
        List<GameObject> complement = farFromOwnGoalFilter.filter();
        List<GameObject> filtredPlayers = players.Except(complement).ToList();
        return filtredPlayers;
    }
}
}