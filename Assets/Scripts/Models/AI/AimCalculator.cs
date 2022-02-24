using UnityEngine;

namespace Aim
{
public class AimCalculator
{
    private Vector3 displacement;
    private Vector3 targetVelocity;

    public AimCalculator(Vector3 sourcePosition, Vector3 targetPosition, Vector3 targetVelocity)
    {
        displacement = targetPosition - sourcePosition;
        // We make displacement.y = 0 to avoid height difference inaccuracy
        displacement.y = 0;
        this.targetVelocity = targetVelocity;
        this.targetVelocity.y = 0;
    }

    public float getMinSpeed()
    {
        float theta = Vector3.Angle(displacement, -targetVelocity);
        if(theta < 90)
            return targetVelocity.magnitude * Mathf.Sin(Mathf.Deg2Rad * theta);
        else
            return targetVelocity.magnitude;
    }

    public Vector3 getOptimalDirection(float speed)
    {
        // target is almost still
        if(Mathf.Approximately(targetVelocity.sqrMagnitude,0))
            return displacement.normalized;

        Vector3 parallelVrel = Vector3.Project(-targetVelocity, displacement);
        Vector3 perpendicularVrel = -targetVelocity - parallelVrel;

        if(speed <= getMinSpeed())
        {
            if(isTargetGettingCloser())
            {
                return -perpendicularVrel.normalized;
            }
            else
            {
                return targetVelocity.normalized;
            }
        }

        Vector3 perpendicularVoptimal = -perpendicularVrel;
        Vector3 parallelVoptimal = parallelVrel.normalized * Mathf.Sqrt(speed*speed - perpendicularVoptimal.sqrMagnitude);
        // if getting away, just change parallel velocity sign
        if(Vector3.Dot(parallelVoptimal, displacement) < 0)
            parallelVoptimal *= -1;
        Vector3 Voptimal = parallelVoptimal + perpendicularVoptimal;
        return Voptimal.normalized;
    }

    public bool isTargetGettingCloser()
    {
        return Vector3.Dot(targetVelocity, displacement) < 0;
    }
}
}