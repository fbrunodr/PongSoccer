using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ConstantsNamespace;

namespace PlayersFilters
{
public class FarFromOwnGoalFilter : PlayersFilter
{
    public FarFromOwnGoalFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball) : base(players, oponents, ball){}

    public override List<GameObject> filter()
    {
        float DISTANCE_THRESHOLD = 45;
        Vector3 ownGoalCenter = FieldDescription.AwayGoalCenter;
        
        List<GameObject> filtredPlayers = new List<GameObject>();
        foreach(GameObject player in players)
        {
            Vector3 playerPosition = player.transform.position;
            playerPosition.y = 0;  
            float distanceFromOwnGoalCenter = (playerPosition - ownGoalCenter).magnitude;
            if(distanceFromOwnGoalCenter > DISTANCE_THRESHOLD)
                filtredPlayers.Add(player);
        }

        return filtredPlayers;
    }
}
}