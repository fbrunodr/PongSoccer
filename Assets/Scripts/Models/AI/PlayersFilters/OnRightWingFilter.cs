using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstantsNamespace;

namespace PlayersFilters
{
public class OnRightWingFilter : PlayersFilter
{
    public OnRightWingFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball) : base(players, oponents, ball){}

    public override List<GameObject> filter()
    {
        // remember AI is always away (plays on the other side of the field)
        List<GameObject> filtredPlayers = players.FindAll(player =>
        player.transform.position.x < -FieldDescription.fieldWidth * 0.2
        );
        return filtredPlayers;
    }
}
}