using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishMatch : MonoBehaviour
{
    public void gotoAfterMatch()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
