using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AInamespace{
public abstract class AI
{
    private List<GameObject> players;
    private float lastMove;
    protected float timeToNextMove;

    public AI(List<GameObject> players)
    {
        this.players = players;
        lastMove = Time.time;
        timeToNextMove = chooseTimeToNextMove();
    }

    public void play()
    {
        if(isReady())
        {
            doMove();
            lastMove = Time.time;
            chooseTimeToNextMove();
        }
    }

    protected abstract float chooseTimeToNextMove();

    private bool isReady()
    {
        return Time.time >= lastMove + timeToNextMove;
    }

    protected abstract void doMove();
}
}