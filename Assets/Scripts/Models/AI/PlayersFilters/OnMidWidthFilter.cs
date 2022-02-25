using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class OnMidWidthFilter : PlayersFilter
{
    private List<GameObject> players;

    public OnMidWidthFilter(List<GameObject> players)
    {
        this.players = players;
    }

    public override List<GameObject> filter()
    {
        OnLeftWingFilter onLeftFilter = new OnLeftWingFilter(players);
        List<GameObject> complement1 = onLeftFilter.filter();

        OnRightWingFilter onRightFilter = new OnRightWingFilter(players);
        List<GameObject> complement2 = onRightFilter.filter();

        List<GameObject> filtredPlayers = players.Except(complement1).ToList().Except(complement2).ToList();
        return filtredPlayers;
    }
}
}