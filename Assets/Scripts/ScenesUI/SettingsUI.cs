using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SettingsUI : MonoBehaviour
{

    public void loadChooseField()
    {
        SceneManager.LoadScene("ChooseField");
    }

    public void gotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
