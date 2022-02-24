using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstantsNamespace;

namespace PlayersFilters
{
public class OnAttackFilter : PlayersFilter
{
    public OnAttackFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball) : base(players, oponents, ball){}

    public override List<GameObject> filter()
    {
        // remember AI is always away (plays on the other side of the field)
        List<GameObject> filtredPlayers = players.FindAll(player =>
        player.transform.position.z < (FieldDescription.awayAttackCenter.z + FieldDescription.awayMidCenter.z)/2
        );
        return filtredPlayers;
    }
}
}