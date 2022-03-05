using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Moves;

namespace AInamespace{
public abstract class AI
{
    int difficult;

    protected List<GameObject> players;
    protected List<GameObject> oponents;
    protected GameObject ball;

    private float lastMove;
    private float timeToNextMove;

    protected AI(List<GameObject> players, List<GameObject> oponents, GameObject ball, int difficult)
    {
        this.players = players;
        this.oponents = oponents;
        this.ball = ball;
        this.difficult = difficult;

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

    private bool isReady()
    {
        return Time.time >= lastMove + timeToNextMove;
    }

    protected void doMove()
    {
        float maxSpeed = getMaxSpeed(timeToNextMove);
        Move move = chooseMove(maxSpeed);
        move.execute();
    }

    protected abstract float chooseTimeToNextMove();

    protected abstract float getMaxSpeed(float timeOfMove);

    protected abstract Move chooseMove(float maxSpeed);
}
}