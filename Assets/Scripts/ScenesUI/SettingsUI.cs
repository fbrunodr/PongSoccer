using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class SettingsUI : MonoBehaviour
{

    AudioListener audioListener;
    EventSystem eventSystem;

    void Start()
    {
        audioListener = GameObject.Find("Main Camera").GetComponent<AudioListener>();
        eventSystem = GameObject.Find("EventSystem").GetComponent<EventSystem>();
    }

    public void loadChooseField()
    {
        audioListener.enabled = false;
        eventSystem.enabled = false;
        SceneManager.LoadScene("ChooseField", LoadSceneMode.Additive);
    }

    public void gotoMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void enableSystemsBack()
    {
        audioListener.enabled = true;
        eventSystem.enabled = true;
    }
}
