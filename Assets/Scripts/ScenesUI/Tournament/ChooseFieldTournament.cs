using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using FieldNamespace;
using TournamentNamespace;
using UnityEngine.SceneManagement;

public class ChooseFieldTournament : MonoBehaviour
{

    List<GameObject> fields;

    // Start is called before the first frame update
    void Start()
    {
        fields = new List<GameObject>(GameObject.FindGameObjectsWithTag("choiceObj"));
        Field currentField = TournamentManager.GetInstance().field;
        selectField(currentField);
    }

    public void selectField(Field field)
    {
        if(field == null)
            return;

        foreach(GameObject fieldObj in fields)
        {
            if(fieldObj.name != field.getName())
                fieldObj.transform.GetChild(1).GetComponent<Text>().color = Color.white;
            else
                fieldObj.transform.GetChild(1).GetComponent<Text>().color = Color.red;
        }
        TournamentManager.GetInstance().field = field;
    }

    public void gotoTournament()
    {
        SceneManager.LoadScene("Tournament");
    }

    public void gotoSetWinCondition()
    {
        SceneManager.LoadScene("Assets/Scenes/PlayMenu/Tournament/SetWinCondition.unity");
    }
}
