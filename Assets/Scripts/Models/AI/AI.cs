using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moves;

namespace AInamespace{
public abstract class AI
{
    protected List<GameObject> players;
    protected List<GameObject> oponents;
    protected GameObject ball;
    private float lastMove;
    private float timeToNextMove;

    protected AI(List<GameObject> players, List<GameObject> oponents, GameObject ball)
    {
        this.players = players;
        this.oponents = oponents;
        this.ball = ball;
        lastMove = Time.time;
        timeToNextMove = chooseTimeToNextMove();
    }

    public void play()
    {
        if(isReady())
        {
            doMove();
            lastMove = Time.time;
            timeToNextMove = chooseTimeToNextMove();
        }
    }

    protected abstract float chooseTimeToNextMove();

    private bool isReady()
    {
        return Time.time >= lastMove + timeToNextMove;
    }

    protected void doMove()
    {
        GameObject player = choosePlayer();
        float maxSpeed = getMaxSpeed(timeToNextMove);
        Move move = chooseMove(player, maxSpeed);
        move.execute();
    }

    protected abstract float getMaxSpeed(float timeOfMove);

    protected abstract GameObject choosePlayer();

    protected abstract Move chooseMove(GameObject player, float maxSpeed);
}
}