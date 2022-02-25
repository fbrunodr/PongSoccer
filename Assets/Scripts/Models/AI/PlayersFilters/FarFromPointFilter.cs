using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PlayersFilters
{
public class FarFromPointFilter : PlayersFilter
{
    private List<GameObject> players;
    private Vector3 point;
    private float distanceThreshold;
    
    public FarFromPointFilter(List<GameObject> players, Vector3 point, float distanceThreshold)
    {
        this.players = players;
        this.point = point;
        this.distanceThreshold = distanceThreshold;
    }

    public FarFromPointFilter(List<GameObject> players, Vector3 point) : this(players, point, 20){}

    public override List<GameObject> filter()
    {
        List<GameObject> filtredPlayers = new List<GameObject>();
        foreach(GameObject player in players)
        {
            Vector3 playerPosition = player.transform.position;
            playerPosition.y = 0;  
            float distanceFromPoint = (playerPosition - point).magnitude;
            if(distanceFromPoint > distanceThreshold)
                filtredPlayers.Add(player);
        }

        return filtredPlayers;
    }
}
}