using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ConstantsNamespace;

public class GoalHandler : MonoBehaviour
{
    private GameObject ball;
    private Vector3 ballInitialPosition;
    private List<GameObject> playersBody;
    private List<Vector3> playersInitialPosition;
    private int homeGoals;
    private int awayGoals;
    
    // Start is called before the first frame update
    void Start()
    {
        homeGoals = 0;
        awayGoals = 0;
        ball = GameObject.Find("Ball").gameObject;
        ballInitialPosition = ball.transform.position;

        playersBody = new List<GameObject>();
        playersInitialPosition = new List<Vector3>();
        for(int i = 0; i < 10; i++)
        {
            GameObject player = GameObject.Find("Home" + i.ToString());
            if(player == null)
            {
                break;
            }
            GameObject playerBody = player.transform.Find("Body").gameObject;
            playersBody.Add(playerBody);
            playersInitialPosition.Add(playerBody.transform.position);

            player = GameObject.Find("Away" + i.ToString());
            playerBody = player.transform.Find("Body").gameObject;
            playersBody.Add(playerBody);
            playersInitialPosition.Add(playerBody.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int goal = getGoal();
        if(goal == 1)
        {
            homeGoals++;
            resetPositions();
            this.GetComponent<PlayerInput>().resetSelectedPlayer();
        }
        else if(goal == -1)
        {
            awayGoals++;
            resetPositions();
            this.GetComponent<PlayerInput>().resetSelectedPlayer();
        }
        
    }

    // 0 -> no goal
    // 1 -> home goal
    // -1 -> away goal
    private int getGoal(){
        Vector3 ballPosition = ball.transform.position;
        if(ballPosition.z > FieldDescription.FIELD_LENGTH / 2 + ball.transform.localScale.x)
            return 1;
        else if(ballPosition.z < -(FieldDescription.FIELD_LENGTH / 2 + ball.transform.localScale.x) )
            return -1;
        else
            return 0;
    }

    private void resetPositions()
    {
        for(int i = 0; i < playersBody.Count; i++)
        {
            playersBody[i].transform.position = playersInitialPosition[i];
            playersBody[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
        ball.transform.position = ballInitialPosition;
        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        // Reset angular position
        ball.GetComponent<Rigidbody>().rotation = Quaternion.identity;
        // Reset angular velocity
        ball.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }
}
