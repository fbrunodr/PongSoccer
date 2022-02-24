using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PlayersFilters
{
public abstract class PlayersFilter
{
    protected List<GameObject> players;
    protected List<GameObject> oponents;
    protected GameObject ball;

    protected PlayersFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball)
    {
        this.players = players;
        this.oponents = oponents;
        this.ball = ball;
    }

    public abstract List<GameObject> filter();

    public List<GameObject> getPlayers()
    {
        return this.players;
    }
}
}
