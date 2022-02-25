using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class OnMidWidthFilter : PlayersFilter
{
    public OnMidWidthFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball) : base(players, oponents, ball){}

    public override List<GameObject> filter()
    {
        OnLeftWingFilter onLeftFilter = new OnLeftWingFilter(players, oponents, ball);
        List<GameObject> complement1 = onLeftFilter.filter();

        OnRightWingFilter onRightFilter = new OnRightWingFilter(players, oponents, ball);
        List<GameObject> complement2 = onRightFilter.filter();

        List<GameObject> filtredPlayers = players.Except(complement1).ToList().Except(complement2).ToList();
        return filtredPlayers;
    }
}
}