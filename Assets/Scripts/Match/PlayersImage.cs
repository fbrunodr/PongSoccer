using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamNamespace;

public class PlayersImage : MonoBehaviour
{
    private List<GameObject> playersBody;
    private List<GameObject> playersImages;
    // Start is called before the first frame update
    void Start()
    {
        string homeImagePath = TeamManager.GetInstance().homeTeam.getImagePath();
        Debug.Log(homeImagePath);
        string awayImagePath = TeamManager.GetInstance().awayTeam.getImagePath();

        Material homeImage = Resources.Load<Material>(homeImagePath);
        Material awayImage = Resources.Load<Material>(awayImagePath);

        playersBody = new List<GameObject>();
        playersImages = new List<GameObject>();
        for(int i = 0; i < 10; i++)
        {
            GameObject player = GameObject.Find("Home" + i.ToString());
            if(player == null)
            {
                break;
            }
            GameObject playerBody = player.transform.Find("Body").gameObject;
            playersBody.Add(playerBody);
            GameObject playerImage = player.transform.Find("Image").gameObject;
            playersImages.Add(playerImage);
            playerImage.GetComponent<Renderer>().material = homeImage;

            player = GameObject.Find("Away" + i.ToString());
            playerBody = player.transform.Find("Body").gameObject;
            playersBody.Add(playerBody);
            playerImage = player.transform.Find("Image").gameObject;
            playersImages.Add(playerImage);
            playerImage.GetComponent<Renderer>().material = awayImage;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < playersBody.Count; i++)
        {
            playersImages[i].transform.position = playersBody[i].transform.position;
        }
    }
}
