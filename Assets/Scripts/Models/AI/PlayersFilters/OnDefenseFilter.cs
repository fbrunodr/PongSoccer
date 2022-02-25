using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstantsNamespace;

namespace PlayersFilters
{
public class OnDefenseFilter : PlayersFilter
{
    private List<GameObject> players;

    public OnDefenseFilter(List<GameObject> players)
    {
        this.players = players;
    }

    public override List<GameObject> filter()
    {
        // remember AI is always away (plays on the other side of the field)
        List<GameObject> filtredPlayers = players.FindAll(player =>
        player.transform.position.z > (FieldDescription.awayDefenseCenter.z + FieldDescription.awayMidCenter.z)/2
        );
        return filtredPlayers;
    }
}
}