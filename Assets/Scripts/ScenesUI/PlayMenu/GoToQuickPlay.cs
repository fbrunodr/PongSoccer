using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToQuickPlay : MonoBehaviour
{
    public void gotoQuickPlay()
    {
        SceneManager.LoadScene("QuickMatch");
    }
}
