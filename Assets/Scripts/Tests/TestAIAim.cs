using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Aim;

public class TestAIAim : MonoBehaviour
{
    private float lastTestTime;

    private Vector3 playerInitialPosition;
    private Vector3 ballInitialPosition;

    private GameObject player;
    private GameObject playerImage;
    private GameObject ball;

    List<Vector3> ballVelocities;
    List<float> speeds;
    List<string> messages;
    private int currentTest;

    // Start is called before the first frame update
    void Start()
    {
        currentTest = 0;
        lastTestTime = Time.time - 2;
        player = GameObject.Find("AI").transform.Find("Body").gameObject;
        playerImage = GameObject.Find("AI").transform.Find("Image").gameObject;
        ball = GameObject.Find("Ball");

        playerInitialPosition = player.transform.position;
        ballInitialPosition = ball.transform.position;

        ballVelocities = new List<Vector3>();
        speeds = new List<float>();
        messages = new List<string>();

        // do nothing
        ballVelocities.Add(Vector3.zero);
        speeds.Add(0);
        messages.Add("Do nothing");
        
        // Go in the ball direction
        // more or equal to ball speed
        ballVelocities.Add(Vector3.zero);
        speeds.Add(30);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(0, 0, 15));
        speeds.Add(45);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(0, 0, 30));
        speeds.Add(45);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(0, 0, 45));
        speeds.Add(45);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(30, 0, 30));
        speeds.Add(45);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(30, 0, 45));
        speeds.Add(60);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(0, 0, -15));
        speeds.Add(30);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(0, 0, -30));
        speeds.Add(30);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(0, 0, -45));
        speeds.Add(30);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(-30, 0, -30));
        speeds.Add(45);
        messages.Add("Move to the ball");

        ballVelocities.Add(new Vector3(30, 0, -45));
        speeds.Add(30);
        messages.Add("Move to the ball");

        // Less than min speed
        ballVelocities.Add(new Vector3(30, 0, 0));
        speeds.Add(30);
        messages.Add("Follow the ball parallel");
        
        ballVelocities.Add(new Vector3(-45, 0, 0));
        speeds.Add(30);
        messages.Add("Follow the ball parallel");
        
        ballVelocities.Add(new Vector3(-75, 0, 0));
        speeds.Add(30);
        messages.Add("Follow the ball parallel");
        
        ballVelocities.Add(new Vector3(60, 0, -45));
        speeds.Add(30);
        messages.Add("Follow the ball parallel while also getting closer");
        
        ballVelocities.Add(new Vector3(60, 0, 45));
        speeds.Add(30);
        messages.Add("Follow the ball parallel while also getting further");
    }


    // Update is called once per frame
    void Update()
    {
        fixPlayerImage();
        if(currentTest < speeds.Count)
        {
            if(Time.time < lastTestTime + 2.0)
                return;
            Reset();
            ball.GetComponent<Rigidbody>().velocity = ballVelocities[currentTest];
            doTest(playerInitialPosition, ballInitialPosition, ballVelocities[currentTest], speeds[currentTest]);
            Debug.Log(messages[currentTest]);
            Debug.Log("Current speed: " + speeds[currentTest].ToString());
            Debug.Log("Min Speed: " + new AimCalculator(playerInitialPosition, ballInitialPosition, ballVelocities[currentTest]).getMinSpeed().ToString());
            lastTestTime = Time.time;
            currentTest++;
        }
    }

    private void Reset()
    {
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.transform.position = playerInitialPosition;

        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // Reset angular position
        ball.GetComponent<Rigidbody>().rotation = Quaternion.identity;
        // Reset angular velocity
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        ball.transform.position = ballInitialPosition;
    }

    private void doTest(Vector3 sourcePosition, Vector3 targetPosition, Vector3 targetVelocity, float speed)
    {
        AimCalculator aimCalculator = new AimCalculator(sourcePosition, targetPosition, targetVelocity);
        Vector3 moveDirection = aimCalculator.getOptimalDirection(speed);
        player.GetComponent<Rigidbody>().velocity = speed * moveDirection;
    }

    private void fixPlayerImage()
    {
        playerImage.transform.position = player.transform.position;
    }
}
