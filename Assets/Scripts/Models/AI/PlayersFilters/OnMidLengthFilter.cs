using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class OnMidLengthFilter : PlayersFilter
{
    private List<GameObject> players;

    public OnMidLengthFilter(List<GameObject> players)
    {
        this.players = players;
    }

    public override List<GameObject> filter()
    {
        OnDefenseFilter onDefenseFilter = new OnDefenseFilter(players);
        List<GameObject> complement1 = onDefenseFilter.filter();

        OnAttackFilter onAttackFilter = new OnAttackFilter(players);
        List<GameObject> complement2 = onAttackFilter.filter();

        List<GameObject> filtredPlayers = players.Except(complement1).ToList().Except(complement2).ToList();
        return filtredPlayers;
    }
}
}