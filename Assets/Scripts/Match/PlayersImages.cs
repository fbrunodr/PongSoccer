using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamNamespace;

public class PlayersImages : MonoBehaviour
{
    private List<GameObject> playersBody;
    private List<GameObject> playersImages;
    // Start is called before the first frame update
    void Start()
    {
        string homeMaterialPath = TeamManager.GetInstance().homeTeam.getMaterialPath();
        string awayMaterialPath = TeamManager.GetInstance().awayTeam.getMaterialPath();

        Material homeMaterial = Resources.Load<Material>(homeMaterialPath);
        Material awayMaterial = Resources.Load<Material>(awayMaterialPath);

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
            playerImage.GetComponent<Renderer>().material = homeMaterial;

            player = GameObject.Find("Away" + i.ToString());
            playerBody = player.transform.Find("Body").gameObject;
            playersBody.Add(playerBody);
            playerImage = player.transform.Find("Image").gameObject;
            playersImages.Add(playerImage);
            playerImage.GetComponent<Renderer>().material = awayMaterial;
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
