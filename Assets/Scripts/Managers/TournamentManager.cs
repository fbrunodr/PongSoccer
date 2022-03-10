using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using FieldNamespace;
using TeamNamespace;
using DifficutiesNamespace;

namespace TournamentNamespace{
public class TournamentManager
{
    public Team playerTeam;
    public Field field;
    public string mode;
    public int goalsToWin;
    public int timeToEnd;
    public Dictionary<string, int>  difficulties;
    public SortedDictionary<(char, int), TeamDataOnGroupPhase> teamsDataOnGroupPhase;

    private string tournamentDirectory;

    private TournamentManager()
    {
        playerTeam = null;
        field = new Field("neighborhood_field");
        mode = "Time";
        goalsToWin = 2;
        timeToEnd = 60;
        difficulties = new Dictionary<string, int>();
        teamsDataOnGroupPhase = new SortedDictionary<(char, int), TeamDataOnGroupPhase>();
        tournamentDirectory = Path.Combine(Application.persistentDataPath, "Tournament");
    }

    public void CreateTournament()
    {
        difficulties.Clear();
        List<string> teamsOrderedByDifficulties = new List<string>();
        // copy by value
        foreach(KeyValuePair<string, int> pair in DifficutiesManager.GetInstance().difficulties)
        {
            difficulties.Add(pair.Key, pair.Value);
            teamsOrderedByDifficulties.Add(pair.Key);
        }

        // First shuffle list to avoid stable sorting
        teamsOrderedByDifficulties = 
        teamsOrderedByDifficulties.OrderByDescending(team => Random.value).ToList();

        // Then order it
        teamsOrderedByDifficulties = 
        teamsOrderedByDifficulties.OrderByDescending(team => difficulties[team]).ToList();

        teamsDataOnGroupPhase.Clear();
        // First eight teams each go to their own group
        // their index is 0 on their group
        for(int i = 0; i < 8; i++)
        {
            teamsDataOnGroupPhase.Add(
                ((char)('a' + i), 0),
                new TeamDataOnGroupPhase( new Team(teamsOrderedByDifficulties[i]) )
            );
        }

        // We skip team 9 (the best don't always get in the tournament)
        // The next 8 teams get selected
        // Their index is 1 on their group
        for(int i = 0; i < 8; i++)
        {
            teamsDataOnGroupPhase.Add(
                ((char)('a' + i), 1),
                new TeamDataOnGroupPhase( new Team(teamsOrderedByDifficulties[i + 9]) )
            );
        }

        // We keep doing a similar proccess
        for(int i = 0; i < 8; i++)
        {
            teamsDataOnGroupPhase.Add(
                ((char)('a' + i), 2),
                new TeamDataOnGroupPhase( new Team(teamsOrderedByDifficulties[i + 25]) )
            );
        }

        // This one is slightly different, so 1
        // star teams get selected more often
        for(int i = 0; i < 8; i ++)
        {
            teamsDataOnGroupPhase.Add(
                ((char)('a' + i), 3),
                new TeamDataOnGroupPhase( new Team(teamsOrderedByDifficulties[2*i + 49]) )
            );
        }

        bool playerTeamHasBeenSelected = false;
        foreach(KeyValuePair<(char, int), TeamDataOnGroupPhase> pair in teamsDataOnGroupPhase)
        {
            TeamDataOnGroupPhase teamDataOnGroupPhase = pair.Value;
            if(teamDataOnGroupPhase.team.Equals(playerTeam))
            {
                playerTeamHasBeenSelected = true;
                break;
            }
        }

        if(!playerTeamHasBeenSelected)
        {
            char randomGroup = ((char)('a' + Random.Range(0, 8)));
            teamsDataOnGroupPhase[(randomGroup, 2)].team = playerTeam;
        }

        Debug.Log(tournamentDirectory);
        saveTournamentSettings();
        saveTournamentDifficulties();
        // save teams group data (group data)
    }

    public void createTournamentDirectoryIfNone()
    {
        if(!Directory.Exists(tournamentDirectory))
        {
            Directory.CreateDirectory(tournamentDirectory);
        }
    }

    public void saveTournamentSettings()
    {
        createTournamentDirectoryIfNone();

        string tournamentSettings = Path.Combine(tournamentDirectory, "settings.txt");
        string settings = "";
        settings += "playerTeam " + playerTeam.getName() + "\n";
        settings += "field " + field.getName() + "\n";
        settings += "mode " + mode + "\n";
        settings += "goalsToWin " + goalsToWin.ToString() + "\n";
        settings += "timeToEnd " + timeToEnd.ToString();
        File.WriteAllText(tournamentSettings, settings);
    }

    public void saveTournamentDifficulties()
    {
        createTournamentDirectoryIfNone();

        string tournamentDifficultiesPath = Path.Combine(tournamentDirectory, "difficulties.txt");
        string tournamentDifficultiesData = "";

        foreach(KeyValuePair<string, int> pair in difficulties)
        {
            string teamName = pair.Key;
            int difficult = pair.Value;
            tournamentDifficultiesData += teamName + " " + difficult.ToString() + "\n";
        }
        // remove trailing end of line
        tournamentDifficultiesData = tournamentDifficultiesData.Remove(tournamentDifficultiesData.Length - 1);

        File.WriteAllText(tournamentDifficultiesPath, tournamentDifficultiesData);
    }

    private static TournamentManager _instance;

    private static readonly object _lock = new object();

    public static TournamentManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new TournamentManager();
                }
            }
        }
        return _instance;
    }
}
}