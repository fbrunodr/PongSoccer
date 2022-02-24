using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class OnMidLengthFilter : PlayersFilter
{
    public OnMidLengthFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball) : base(players, oponents, ball){}

    public override List<GameObject> filter()
    {
        OnDefenseFilter onDefenseFilter = new OnDefenseFilter(players, oponents, ball);
        List<GameObject> complement1 = onDefenseFilter.filter();

        OnAttackFilter onAttackFilter = new OnAttackFilter(players, oponents, ball);
        List<GameObject> complement2 = onAttackFilter.filter();

        List<GameObject> filtredPlayers = players.Except(complement1).ToList().Except(complement2).ToList();
        return filtredPlayers;
    }
}
}