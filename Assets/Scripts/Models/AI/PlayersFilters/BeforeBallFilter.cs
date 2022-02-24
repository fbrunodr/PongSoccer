using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class BeforeBallFilter : PlayersFilter
{
    public BeforeBallFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball) : base(players, oponents, ball){}

    public override List<GameObject> filter()
    {
        // remember AI is always away (plays on the other side of the field)
        List<GameObject> filtredPlayers = players.FindAll(player => player.transform.position.z > ball.transform.position.z);
        return filtredPlayers;
    }
}
}