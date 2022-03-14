using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TeamNamespace;
using TournamentNamespace;

public class GroupUI : MonoBehaviour
{

    SortedDictionary<char, List<TeamDataOnGroupPhase> > teamsSorted;

    // Start is called before the first frame update
    void Start()
    {
        teamsSorted = new SortedDictionary<char, List<TeamDataOnGroupPhase>>();

        GameObject content = GameObject.Find("Content");
        foreach(Transform group in content.transform)
        {
            char letter = group.name[0];

            List<TeamDataOnGroupPhase> teamsOfThisGroup = new List<TeamDataOnGroupPhase>();
            for(int i = 0; i < 4; i++)
            {
                teamsOfThisGroup.Add(
                    TournamentManager.GetInstance().teamsDataOnGroupPhase[(letter, i)]
                );
            }

            teamsOfThisGroup = teamsOfThisGroup.OrderByDescending(
                team => (team.points, team.goalDifference, team.goalsFor, team.wins,
                TournamentManager.GetInstance().difficulties[team.team.getName()], team.team.getName() )
            ).ToList();

            teamsSorted.Add(letter, teamsOfThisGroup);

            for(int i = 3; i < 7; i++)
            {
                TeamDataOnGroupPhase teamOfThisGroup = teamsOfThisGroup[i-3];
                GameObject teamUI = group.GetChild(i).gameObject;
                Sprite teamImg = Resources.Load<Sprite>(teamOfThisGroup.team.getImagePath());
                teamUI.transform.Find("Image").GetComponent<Image>().sprite = teamImg;
                teamUI.transform.Find("MP").GetComponent<Text>().text = teamOfThisGroup.matchesPlayed.ToString();
                teamUI.transform.Find("W").GetComponent<Text>().text = teamOfThisGroup.wins.ToString();
                teamUI.transform.Find("D").GetComponent<Text>().text = teamOfThisGroup.draws.ToString();
                teamUI.transform.Find("L").GetComponent<Text>().text = teamOfThisGroup.losses.ToString();
                teamUI.transform.Find("GF").GetComponent<Text>().text = teamOfThisGroup.goalsFor.ToString();
                teamUI.transform.Find("GD").GetComponent<Text>().text = teamOfThisGroup.goalDifference.ToString();
                teamUI.transform.Find("Pts").GetComponent<Text>().text = teamOfThisGroup.points.ToString();
            }
        }
    }
}
