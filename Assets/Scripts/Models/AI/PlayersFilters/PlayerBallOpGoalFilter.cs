using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using ConstantsNamespace;

namespace PlayersFilters
{
public class PlayerBallOpGoalFilter : PlayersFilter
{
    private List<GameObject> players;
    private GameObject ball;

    public PlayerBallOpGoalFilter(List<GameObject> players, GameObject ball)
    {
        this.players = players;
        this.ball = ball;
    }

    public override List<GameObject> filter()
    {
        List<GameObject> filtredPlayers = players.FindAll(player => alignedPlayerBallandOppositeGoal(player, ball));
        return filtredPlayers;
    }

    private bool alignedPlayerBallandOppositeGoal(GameObject player, GameObject ball)
    {
        Vector3 oppositeGoalCenter = FieldDescription.HomeGoalCenter;
        float goalWidth = FieldDescription.GoalWidth;
        Plane oppositeGoalPlane = new Plane(Vector3.back, oppositeGoalCenter);

        Vector3 origin = player.transform.position;
        origin.y =  0;
        Vector3 target = ball.transform.position;
        target.y = 0;
        Vector3 direction = (target - origin).normalized;
        Ray ray = new Ray(origin, direction);

        float enter = 0;
        if(oppositeGoalPlane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            float distanceFromGoalCenter = (hitPoint - oppositeGoalCenter).magnitude;
            return distanceFromGoalCenter < goalWidth / 2;
        }

        return false;
    }
}
}