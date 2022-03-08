using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectWinCondition : MonoBehaviour
{
    public void selectMode()
    {
        if(!this.GetComponent<Toggle>().isOn)
            return;
        string mode = this.name;
        GameObject.Find("SetWinConditionCanvas").GetComponent<SetWinConditionUI>().selectMode(mode);
    }
    public void selectDuration()
    {
        if(!this.GetComponent<Toggle>().isOn)
            return;
        string duration = this.name;
        GameObject.Find("SetWinConditionCanvas").GetComponent<SetWinConditionUI>().selectDuration(duration);
    }
}
