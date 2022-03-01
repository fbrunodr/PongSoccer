using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WinConditionNamespace;

public class TimeHandler : MonoBehaviour
{

    private float seconds;
    private bool decrementing;
    private float referenceTime;

    // Start is called before the first frame update
    void Start()
    {
        string mode = WinCondition.GetInstance().mode;
        if(mode == "Time" || mode == "Time and golden goal")
        {
            decrementing = true;
            seconds = WinCondition.GetInstance().timeToEnd;
            referenceTime = Time.time + seconds;
        }
        else
        {
            decrementing = false;
            seconds = 0;
            referenceTime = Time.time;
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(decrementing)
        {
            seconds = referenceTime - Time.time;
        }
        else
        {
            seconds = Time.time - referenceTime;
        }
    }

    public float getSeconds()
    {
        return seconds;
    }
}
