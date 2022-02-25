using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayersFilters;

public class TestPlayersFilters : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        List<GameObject> players = new List<GameObject>();
        for(int i = 0; i < 100; i++)
        {
            GameObject player = GameObject.Find("AI" + i.ToString());
            if(player == null)
                break;
            GameObject playerRigidBody = player.transform.Find("Body").gameObject;
            players.Add(playerRigidBody);
        }

        GameObject ball = GameObject.Find("Ball");

        // Choose filter here to test
        CloseToBallFilter filter = new CloseToBallFilter(players, ball);
        List<GameObject> filteredPlayers = filter.filter();
        // See results here   
        Debug.Log("CloseToBallFilter:");
        foreach(GameObject filteredPlayer in filteredPlayers)
        {
            Debug.Log(filteredPlayer.transform.position);
        }
    }
}
