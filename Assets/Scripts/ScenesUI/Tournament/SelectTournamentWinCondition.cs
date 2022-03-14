using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using WinConditionNamespace;

public class SelectTournamentWinCondition : MonoBehaviour
{
    public void selectMode()
    {
        if(!this.GetComponent<Toggle>().isOn)
            return;
        string modeName = this.name;
        WinCondition.Mode mode = WinCondition.stringToMode(modeName);
        GameObject.Find("Canvas").GetComponent<SetTournamentWinConditionUI>().selectMode(mode);
    }

    public void selectDuration()
    {
        if(!this.GetComponent<Toggle>().isOn)
            return;
        string duration = this.name;
        GameObject.Find("Canvas").GetComponent<SetTournamentWinConditionUI>().selectDuration(duration);
    }
}
