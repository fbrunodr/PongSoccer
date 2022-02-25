using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class CloseFromPoint : PlayersFilter
{
    private List<GameObject> players;
    private Vector3 point;
    private float distanceThreshold;
    
    public CloseFromPoint(List<GameObject> players, Vector3 point, float distanceThreshold)
    {
        this.players = players;
        this.point = point;
        this.distanceThreshold = distanceThreshold;
    }

    public CloseFromPoint(List<GameObject> players, Vector3 point) : this(players, point, 20){}

    public override List<GameObject> filter()
    {
        FarFromPointFilter farFromPointFilter = new FarFromPointFilter(players, point, distanceThreshold);
        List<GameObject> complement = farFromPointFilter.filter();
        List<GameObject> filtredPlayers = players.Except(complement).ToList();
        return filtredPlayers;
    }
}
}