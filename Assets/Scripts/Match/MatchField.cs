using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FieldNamespace;

public class MatchField : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        string fieldImagePath = FieldManager.GetInstance().field.getImagePath();
        Material fieldMaterial = Resources.Load<Material>(fieldImagePath);
        GameObject.Find("Field").GetComponent<Renderer>().material = fieldMaterial;

        string time = FieldManager.GetInstance().time;
        if(time == "Noon")
            return;
        if(time == "Afternoon")
        {
            GameObject.Find("Directional Light").transform.Rotate(55 * Vector3.left, Space.Self);
            foreach(Transform lightPost in GameObject.Find("LightPosts").transform)
            {
                lightPost.gameObject.GetComponent<Light>().intensity = 0.75f;
            }
        }
        if(time == "Evening")
        {
            GameObject.Find("Directional Light").transform.Rotate(40 * Vector3.left, Space.Self);
            foreach(Transform lightPost in GameObject.Find("LightPosts").transform)
            {
                lightPost.gameObject.GetComponent<Light>().intensity = 1.5f;
            }
        }
    }
}
