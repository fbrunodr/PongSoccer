using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamNamespace;

public class SelectHomeTeam : MonoBehaviour
{
    // Start is called before the first frame update
    public void selectHomeTeam()
    {
        Team thisTeam = new Team(this.name);
        GameObject.Find("Canvas").GetComponent<ChooseTeams>().selectHomeTeam(thisTeam);
    }
}
