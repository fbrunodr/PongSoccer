using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using FieldNamespace;

public class ChooseFieldUI : MonoBehaviour
{

    List<GameObject> fields;
    Field chosenField;

    void Start()
    {
        fields = new List<GameObject>(GameObject.FindGameObjectsWithTag("choiceObj"));
        selectField(FieldManager.GetInstance().field);
    }

    public void selectField(Field field)
    {
        if(field == null)
            return;
        if(chosenField != null && field.getName() == chosenField.getName())
            return;

        foreach(GameObject fieldObj in fields)
        {
            if(fieldObj.name != field.getName())
                fieldObj.transform.GetChild(1).GetComponent<Text>().color = Color.white;
            else
                fieldObj.transform.GetChild(1).GetComponent<Text>().color = Color.red;
        }
        chosenField = field;
    }

    public void save()
    {
        FieldManager.GetInstance().field = chosenField;
        SceneManager.UnloadSceneAsync("ChooseField");
    }

    public void cancel()
    {
        SceneManager.UnloadSceneAsync("ChooseField");
    }
}
