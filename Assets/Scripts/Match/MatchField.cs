using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FieldNamespace;
using GameTypeNamespace;
using TournamentNamespace;

public class MatchField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string fieldImagePath = "";

        GameType gameType = GameTypeManager.GetInstance().type;
        if(gameType == GameType.QuickMatch)
            fieldImagePath = FieldManager.GetInstance().field.getImagePath();
        else if(gameType == GameType.Tournament)
            fieldImagePath = TournamentManager.GetInstance().field.getImagePath();

        Material fieldMaterial = Resources.Load<Material>(fieldImagePath);
        GameObject.Find("Field").GetComponent<Renderer>().material = fieldMaterial;

        TimeOfMatch time = TimeOfMatch.Noon;
        if(gameType == GameType.QuickMatch)
            time = FieldManager.GetInstance().time;
        else if(gameType == GameType.Tournament)
            time = TournamentManager.GetInstance().getTimeOfMatch();

        if(time == TimeOfMatch.Noon)
            return;
        if(time == TimeOfMatch.Afternoon)
        {
            GameObject.Find("Directional Light").transform.Rotate(55 * Vector3.left, Space.Self);
            foreach(Transform lightPost in GameObject.Find("LightPosts").transform)
            {
                lightPost.gameObject.GetComponent<Light>().intensity = 0.75f;
            }
        }
        if(time == TimeOfMatch.Evening)
        {
            GameObject.Find("Directional Light").transform.Rotate(40 * Vector3.left, Space.Self);
            foreach(Transform lightPost in GameObject.Find("LightPosts").transform)
            {
                lightPost.gameObject.GetComponent<Light>().intensity = 1.5f;
            }
        }
    }
}
