using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ConstantsNamespace;
using PlayersFilters;
using Moves;

namespace AInamespace{
public class AI4x4 : AI
{
    public AI4x4(List<GameObject> players, List<GameObject> oponents, GameObject ball) :
    base(players, oponents, ball){}

    protected override float chooseTimeToNextMove()
    {
        return Random.Range(GameConstants.MAX_TIME/3, GameConstants.MAX_TIME);
    }

    protected override float getMaxSpeed(float timeOfMove)
    {
        return GameConstants.MAX_SPEED * timeOfMove / GameConstants.MAX_TIME;
    }

    protected override GameObject choosePlayer()
    {
        return players[(int)Random.Range(0,2.99f)];
    }

    protected override Move chooseMove(GameObject player, float maxSpeed)
    {
        return new Move(player, ball.transform.position, maxSpeed);
    }
}
}
