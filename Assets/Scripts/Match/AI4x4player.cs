using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AInamespace;

public class AI4x4player : MonoBehaviour
{

    AI4x4 ai;

    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> players = new List<GameObject>();
        for(int i = 0; i < 4; i++)
        {
            GameObject player = GameObject.Find("Away" + i.ToString()).transform.Find("Body").gameObject;
            if(player == null)
                break;
            players.Add(player);
        }

        List<GameObject> oponents = new List<GameObject>();
        for(int i = 0; i < 4; i++)
        {
            GameObject oponent = GameObject.Find("Home" + i.ToString()).transform.Find("Body").gameObject;
            if(oponent == null)
                break;
            oponents.Add(oponent);
        }

        GameObject ball = GameObject.Find("Ball");

        ai = new AI4x4(players, oponents, ball);
    }

    // Update is called once per frame
    void Update()
    {
        ai.play();        
    }
}
