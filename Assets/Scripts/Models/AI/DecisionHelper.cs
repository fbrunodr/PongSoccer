using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstantsNamespace;

namespace DecisionHelpers{
public static class DecisionHelper
{
    public static bool isBallGoingToOurDefense(GameObject ball)
    {
        return ball.GetComponent<Rigidbody>().velocity.z > 0;
    }

    public static bool isBallGoingToAttcack(GameObject ball)
    {
        return isBallGoingToOurDefense(ball);
    }

    public static bool isBallGoingToOurGoal(GameObject ball)
    {
        if(Mathf.Approximately(ball.GetComponent<Rigidbody>().velocity.magnitude,0))
            return false;
            
        Plane ourGoalPlane = new Plane(Vector3.forward, FieldDescription.AwayGoalCenter);
        Vector3 ballPos = ball.transform.position;
        ballPos.y = 0;
        Ray ray = new Ray(ballPos, ball.GetComponent<Rigidbody>().velocity.normalized);

        float enterDist = 0;
        if(ourGoalPlane.Raycast(ray, out enterDist))
        {
            Vector3 hitpoint = ray.GetPoint(enterDist);
            return Mathf.Abs(hitpoint.x) < FieldDescription.GoalWidth / 2;
        }

        return false;
    }

    public static bool isBallGoingToTheirGoal(GameObject ball)
    {
        if(Mathf.Approximately(ball.GetComponent<Rigidbody>().velocity.magnitude,0))
            return false;

        Plane theirGoalPlane = new Plane(Vector3.back, FieldDescription.HomeGoalCenter);
        Vector3 ballPos = ball.transform.position;
        ballPos.y = 0;
        Ray ray = new Ray(ballPos, ball.GetComponent<Rigidbody>().velocity.normalized);

        float enterDist = 0;
        if(theirGoalPlane.Raycast(ray, out enterDist))
        {
            Vector3 hitpoint = ray.GetPoint(enterDist);
            return Mathf.Abs(hitpoint.x) < FieldDescription.GoalWidth / 2;
        }

        return false;
    }

    public static bool isBallFarFromPoint(GameObject ball, Vector3 point)
    {
        float distanceThreshold = 25;
        return (point - ball.transform.position).magnitude > distanceThreshold;
    }

    public static bool isBallCloseToPoint(GameObject ball, Vector3 point)
    {
        return isBallFarFromPoint(ball, point);
    }

}
}
