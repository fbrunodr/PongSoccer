using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectTournamentWinCondition : MonoBehaviour
{
    public void selectMode()
    {
        if(!this.GetComponent<Toggle>().isOn)
            return;
        string mode = this.name;
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
