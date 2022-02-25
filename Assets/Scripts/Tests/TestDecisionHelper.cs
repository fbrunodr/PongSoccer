using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DecisionHelpers;

public class TestDecisionHelper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject ball = GameObject.Find("Ball");
        ball.GetComponent<Rigidbody>().velocity = new Vector3(23,0,-82);
        Debug.Log(DecisionHelper.isBallGoingToTheirGoal(ball));
    }
}
