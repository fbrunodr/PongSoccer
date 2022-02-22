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
    }
}
