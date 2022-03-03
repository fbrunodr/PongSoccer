using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FieldNamespace;

public class SelectField : MonoBehaviour
{
    public void selectField()
    {
        Field field = new Field(this.name);
        GameObject.Find("ChooseFieldCanvas").GetComponent<ChooseFieldUI>().selectField(field);
    }
}
