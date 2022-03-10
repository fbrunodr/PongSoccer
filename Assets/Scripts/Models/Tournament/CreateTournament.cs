using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TournamentNamespace;

public class CreateTournament : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TournamentManager.GetInstance().CreateTournament();
    }

}
