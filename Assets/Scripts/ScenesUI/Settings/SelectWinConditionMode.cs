using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectWinConditionMode : MonoBehaviour
{
    public void selectMode()
    {
        string mode = this.name;
        GameObject.Find("SetWinConditionCanvas").GetComponent<SetWinConditionUI>().selectMode(mode);
    }
    public void selectDuration()
    {
        string duration = this.name;
        GameObject.Find("SetWinConditionCanvas").GetComponent<SetWinConditionUI>().selectDuration(duration);
    }
}
