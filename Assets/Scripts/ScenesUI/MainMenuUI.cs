using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuUI : MonoBehaviour
{
    public void gotoPlayMenu()
    {
        SceneManager.LoadScene("PlayMenu");
    }

    public void gotoSettings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
