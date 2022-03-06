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
        Field currentField = FieldManager.GetInstance().field;
        selectField(currentField);
        string currentTime = FieldManager.GetInstance().time;
        setTime(currentTime);
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

    public string getTime()
    {
        GameObject chooseTime = GameObject.Find("ChooseTime");
        foreach(Transform child in chooseTime.transform)
            if(child.gameObject.GetComponent<Toggle>().isOn)
                return child.name;
        return "Noon";
    }

    public void setTime(string currentTime)
    {
        GameObject chooseTime = GameObject.Find("ChooseTime");
        foreach(Transform child in chooseTime.transform)
            if(child.name == currentTime)
            {
                child.gameObject.GetComponent<Toggle>().isOn = true;
                return;
            }
    }

    public void save()
    {
        FieldManager.GetInstance().field = chosenField;
        FieldManager.GetInstance().time = getTime();
        SceneManager.UnloadSceneAsync("ChooseField");
        makeSettingsIteractiveAgain();
    }

    public void cancel()
    {
        SceneManager.UnloadSceneAsync("ChooseField") ;
        makeSettingsIteractiveAgain();
    }

    private void makeSettingsIteractiveAgain()
    {
        GameObject.Find("Canvas").GetComponent<SettingsUI>().enableSystemsBack();
    }
}
