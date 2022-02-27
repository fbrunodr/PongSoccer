using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PerceptionNamespace;

using ConstantsNamespace;

// The test is done with multiple players called AI0, AI1, AI2, ...
public class TestPerception : MonoBehaviour
{

    List<GameObject> players;
    List<GameObject> playersImages;

    // Start is called before the first frame update
    void Start()
    {
        players = new List<GameObject>();
        playersImages = new List<GameObject>();
        for(int i = 0; i < 100; i++)
        {
            GameObject player = GameObject.Find("AI" + i.ToString());
            if(player == null)
            {
                break;
            }
            GameObject playerBody = player.transform.Find("Body").gameObject;
            players.Add(playerBody);
            GameObject playerImage = player.transform.Find("Image").gameObject;
            playersImages.Add(playerImage);
        }

        GameObject ball = GameObject.Find("Ball");
        Vector3 ballPos = ball.transform.position;

        Perception see = new Perception(players, new List<GameObject>(), ball);
        foreach(GameObject player in players.FindAll(player => see.alignedWithBallAndOwnGoal(player)))
        {
            MaterialPropertyBlock propertyBlock = new MaterialPropertyBlock();
            Color newColor = Color.blue;
            propertyBlock.SetColor("_Color", newColor);
            player.gameObject.GetComponent<Renderer>().SetPropertyBlock(propertyBlock);
        }
    }


    // Update is called once per frame
    void Update()
    {
        fixPlayerImage();
    }

    private void fixPlayerImage()
    {
        for(int i = 0; i < players.Count; i++)
            playersImages[i].transform.position = players[i].transform.position;
    }
}
