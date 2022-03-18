using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GameTypeNamespace;

public class FinishMatch : MonoBehaviour
{
    public void gotoAfterMatch()
    {
        if(GameTypeManager.GetInstance().type == GameType.QuickMatch)
            SceneManager.LoadScene("MainMenu");
        else if(GameTypeManager.GetInstance().type == GameType.Tournament)
            SceneManager.LoadScene("Groups");
    }
}
