using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ConstantsNamespace;

namespace PlayersFilters
{
public class PlayerBallOwnGoalFilter : PlayersFilter
{
    public PlayerBallOwnGoalFilter(List<GameObject> players, List<GameObject> oponents, GameObject ball) : base(players, oponents, ball){}

    public override List<GameObject> filter()
    {
        List<GameObject> filtredPlayers = players.FindAll(player => alignedPlayerBallandOwnGoal(player, ball));
        return filtredPlayers;
    }

    private bool alignedPlayerBallandOwnGoal(GameObject player, GameObject ball)
    {
        Vector3 ownGoalCenter = FieldDescription.AwayGoalCenter;
        float goalWidth = FieldDescription.GoalWidth;
        Plane ownGoalPlane = new Plane(Vector3.back, ownGoalCenter);

        Vector3 origin = player.transform.position;
        origin.y =  0;
        Vector3 target = ball.transform.position;
        target.y = 0;
        Vector3 direction = (target - origin).normalized;
        Ray ray = new Ray(origin, direction);

        float enter = 0;
        if(ownGoalPlane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            float distanceFromGoalCenter = (hitPoint - ownGoalCenter).magnitude;
            return distanceFromGoalCenter < goalWidth / 2;
        }

        return false;
    }
}
}