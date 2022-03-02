using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TeamNamespace;

public class SelectAwayTeam : MonoBehaviour
{
    // Start is called before the first frame update
    public void selectAwayTeam()
    {
        Team thisTeam = new Team(this.name);
        GameObject.Find("Canvas").GetComponent<ChooseTeams>().selectAwayTeam(thisTeam);
    }
}
