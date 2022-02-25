using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class CloseToOwnGoalFilter : PlayersFilter
{
    private List<GameObject> players;
    
    public CloseToOwnGoalFilter(List<GameObject> players)
    {
        this.players = players;
    }

    public override List<GameObject> filter()
    {
        FarFromOwnGoalFilter farFromOwnGoalFilter = new FarFromOwnGoalFilter(players);
        List<GameObject> complement = farFromOwnGoalFilter.filter();
        List<GameObject> filtredPlayers = players.Except(complement).ToList();
        return filtredPlayers;
    }
}
}