using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FieldNamespace;

public class SelectFieldTournament : MonoBehaviour
{
    public void selectField()
    {
        Field field = new Field(this.name);
        GameObject.Find("Canvas").GetComponent<ChooseFieldTournament>().selectField(field);
    }
}
