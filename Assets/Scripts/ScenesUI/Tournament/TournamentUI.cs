using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TournamentUI : MonoBehaviour
{
    public void gotoPlayMenu()
    {
        SceneManager.LoadScene("PlayMenu");
    }

    public void gotoChooseField()
    {
        SceneManager.LoadScene("Assets/Scenes/PlayMenu/Tournament/ChooseField.unity");
    }
}
