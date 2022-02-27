using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using ConstantsNamespace;

namespace PerceptionNamespace
{
public class Perception
{

    List<GameObject> players;
    List<GameObject> oponents;
    GameObject ball;

    public Perception(List<GameObject> players, List<GameObject> oponents, GameObject ball)
    {
        this.players = players;
        this.oponents = oponents;
        this.ball = ball;
    }
    
    public GameObject getKeeper()
    {
        return players.Find(player => player.tag == "Keeper");
    }

    public List<GameObject> getNonKeepers()
    {
        return players.FindAll(player => player.tag != "Keeper");
    }

    public bool isBeforePoint(GameObject obj, Vector3 point)
    {
        return obj.transform.position.z > point.z;
    }

    public bool isAfterPoint(GameObject obj, Vector3 point)
    {
        return !isBeforePoint(obj, point);
    }

    public bool isCloseToPoint(GameObject obj, Vector3 point)
    {
        float distanceThreshold = 30;
        return (obj.transform.position - point).magnitude <= distanceThreshold;
    }

    public bool isFarFromPoint(GameObject obj, Vector3 point)
    {
        return !isCloseToPoint(obj, point);
    }

    public bool isCloseToOwnGoalArea(GameObject obj)
    {
        float distanceThreshold = 40;
        return (obj.transform.position - FieldDescription.AWAY_GOAL_CENTER).magnitude <= distanceThreshold;
    }

    public bool isCloseToOtherGoalArea(GameObject obj)
    {
        float distanceThreshold = 40;
        return (obj.transform.position - FieldDescription.HOME_GOAL_CENTER).magnitude <= distanceThreshold;
    }

    public bool isOnAttack(GameObject obj)
    {
        return obj.transform.position.z < (FieldDescription.AWAY_ATTACK_CENTER.z + FieldDescription.AWAY_MID_CENTER.z)/2;
    }

    public bool isOnDefense(GameObject obj)
    {
        return obj.transform.position.z > (FieldDescription.AWAY_DEFENSE_CENTER.z + FieldDescription.AWAY_MID_CENTER.z)/2;
    }

    public bool isOnMidLength(GameObject obj)
    {
        if(isOnDefense(obj)) return false;
        if(isOnAttack(obj)) return false;
        return true;
    }

    public bool isOnLeftWing(GameObject obj)
    {
        return obj.transform.position.x > FieldDescription.FIELD_WIDTH * 0.23;
    }

    public bool isOnRightWing(GameObject obj)
    {
        return obj.transform.position.x < -FieldDescription.FIELD_WIDTH * 0.23;
    }

    public bool isOnMidWidth(GameObject obj)
    {
        if(isOnLeftWing(obj)) return false;
        if(isOnRightWing(obj)) return false;
        return true;
    }

    public bool ballGoingToOwnGoal()
    {
        if(Mathf.Approximately(ball.GetComponent<Rigidbody>().velocity.magnitude,0))
            return false;
            
        Plane ownGoalPlane = new Plane(Vector3.forward, FieldDescription.AWAY_GOAL_CENTER);
        Vector3 ballPos = ball.transform.position;
        ballPos.y = 0;
        Ray ray = new Ray(ballPos, ball.GetComponent<Rigidbody>().velocity.normalized);

        float enterDist = 0;
        if(ownGoalPlane.Raycast(ray, out enterDist))
        {
            Vector3 hitpoint = ray.GetPoint(enterDist);
            return Mathf.Abs(hitpoint.x) < FieldDescription.GOAL_WIDTH / 2;
        }

        return false;
    }

    public bool ballGoingToOtherGoal()
    {
        if(Mathf.Approximately(ball.GetComponent<Rigidbody>().velocity.magnitude,0))
            return false;

        Plane otherGoalPlane = new Plane(Vector3.back, FieldDescription.HOME_GOAL_CENTER);
        Vector3 ballPos = ball.transform.position;
        ballPos.y = 0;
        Ray ray = new Ray(ballPos, ball.GetComponent<Rigidbody>().velocity.normalized);

        float enterDist = 0;
        if(otherGoalPlane.Raycast(ray, out enterDist))
        {
            Vector3 hitpoint = ray.GetPoint(enterDist);
            return Mathf.Abs(hitpoint.x) < FieldDescription.GOAL_WIDTH / 2;
        }

        return false;
    }

    public bool alignedWithBallAndOtherGoal(GameObject obj)
    {
        Vector3 oppositeGoalCenter = FieldDescription.HOME_GOAL_CENTER;
        float goalWidth = FieldDescription.GOAL_WIDTH;
        Plane oppositeGoalPlane = new Plane(Vector3.back, oppositeGoalCenter);

        Vector3 origin = obj.transform.position;
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

    public bool alignedWithBallAndOwnGoal(GameObject obj)
    {
        Vector3 ownGoalCenter = FieldDescription.AWAY_GOAL_CENTER;
        float goalWidth = FieldDescription.GOAL_WIDTH;
        Plane oppositeGoalPlane = new Plane(Vector3.forward, ownGoalCenter);

        Vector3 origin = obj.transform.position;
        origin.y =  0;
        Vector3 target = ball.transform.position;
        target.y = 0;
        Vector3 direction = (target - origin).normalized;
        Ray ray = new Ray(origin, direction);

        float enter = 0;
        if(oppositeGoalPlane.Raycast(ray, out enter))
        {
            Vector3 hitPoint = ray.GetPoint(enter);
            float distanceFromGoalCenter = (hitPoint - ownGoalCenter).magnitude;
            return distanceFromGoalCenter < goalWidth / 2;
        }

        return false;
    }
}
}