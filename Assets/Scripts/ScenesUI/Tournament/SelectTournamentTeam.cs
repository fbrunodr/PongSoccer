using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TeamNamespace;

public class SelectTournamentTeam : MonoBehaviour
{
    // Start is called before the first frame update
    public void selectTournamentTeam()
    {
        Team thisTeam = new Team(this.name);
        GameObject.Find("Canvas").GetComponent<ChooseTournamentTeamUI>().selectTournamentTeam(thisTeam);
    }
}
