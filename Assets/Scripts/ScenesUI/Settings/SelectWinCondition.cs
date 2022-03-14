using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WinConditionNamespace;

public class SelectWinCondition : MonoBehaviour
{
    public void selectMode()
    {
        if(!this.GetComponent<Toggle>().isOn)
            return;
        string modeName = this.name;
        WinCondition.Mode mode = WinCondition.stringToMode(modeName);
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
