using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstantsNamespace;

namespace PlayersFilters
{
public class OnLeftWingFilter : PlayersFilter
{
    private List<GameObject> players;

    public OnLeftWingFilter(List<GameObject> players){
        this.players = players;
    }

    public override List<GameObject> filter()
    {
        // remember AI is always away (plays on the other side of the field)
        List<GameObject> filtredPlayers = players.FindAll(player =>
        player.transform.position.x > FieldDescription.fieldWidth * 0.2
        );
        return filtredPlayers;
    }
}
}