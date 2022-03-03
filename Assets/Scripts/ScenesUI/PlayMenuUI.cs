using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenuUI : MonoBehaviour
{
    public void gotoQuickMatch()
    {
        SceneManager.LoadScene("QuickMatch");
    }

    public void gotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
