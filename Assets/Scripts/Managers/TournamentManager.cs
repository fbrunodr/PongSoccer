using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using FieldNamespace;
using TeamNamespace;
using DifficutiesNamespace;
using WinConditionNamespace;
using AInamespace;
using Utils;

namespace TournamentNamespace{
public class TournamentManager
{
    public Team playerTeam;
    public Team oponent;
    public Field field;
    public WinCondition.Mode mode;
    public int goalsToWin;
    public int timeToEnd;
    public Dictionary<string, int>  difficulties;
    public SortedDictionary<(char, int), TeamDataOnGroupPhase> teamsDataOnGroupPhase;
    private int roundsPlayed;

    private string tournamentDirectory;

    private TournamentManager()
    {
        playerTeam = null;
        field = new Field("neighborhood_field");
        mode = WinCondition.Mode.Time;
        goalsToWin = 2;
        timeToEnd = 60;
        difficulties = new Dictionary<string, int>();
        teamsDataOnGroupPhase = new SortedDictionary<(char, int), TeamDataOnGroupPhase>();
        roundsPlayed = 0;
        oponent = null;
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

        List<List<int>> shuffledIdx = new List<List<int>>();
        for(int i = 0; i < 8; i++)
        {
            shuffledIdx.Add(new List<int>(){0, 1, 2, 3});
            shuffledIdx[i] = 
            shuffledIdx[i].OrderBy(idx => Random.value).ToList();
        }

        teamsDataOnGroupPhase.Clear();
        // First eight teams each go to their own group
        // their index is 0 on their group
        for(int i = 0; i < 8; i++)
        {
            teamsDataOnGroupPhase.Add(
                ((char)('A' + i), shuffledIdx[i][0]),
                new TeamDataOnGroupPhase( new Team(teamsOrderedByDifficulties[i]) )
            );
        }

        // We skip team 9 (the best don't always get in the tournament)
        // The next 8 teams get selected
        // Their index is 1 on their group
        for(int i = 0; i < 8; i++)
        {
            teamsDataOnGroupPhase.Add(
                ((char)('A' + i), shuffledIdx[i][1]),
                new TeamDataOnGroupPhase( new Team(teamsOrderedByDifficulties[i + 9]) )
            );
        }

        // We keep doing a similar proccess
        for(int i = 0; i < 8; i++)
        {
            teamsDataOnGroupPhase.Add(
                ((char)('A' + i), shuffledIdx[i][2]),
                new TeamDataOnGroupPhase( new Team(teamsOrderedByDifficulties[i + 25]) )
            );
        }

        // This one is slightly different, so 1
        // star teams get selected more often
        for(int i = 0; i < 8; i ++)
        {
            teamsDataOnGroupPhase.Add(
                ((char)('A' + i), shuffledIdx[i][3]),
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
            char randomGroup = ((char)('A' + Random.Range(0, 8)));
            teamsDataOnGroupPhase[(randomGroup, 2)].team = playerTeam;
        }

        Debug.Log(tournamentDirectory);
        saveTournamentSettings();
        saveTournamentDifficulties();
        saveGroupsData();
        saveRoundsData();
    }

    private void createTournamentDirectoryIfNone()
    {
        if(!Directory.Exists(tournamentDirectory))
        {
            Directory.CreateDirectory(tournamentDirectory);
        }
    }

    private void saveTournamentSettings()
    {
        createTournamentDirectoryIfNone();

        string tournamentSettings = Path.Combine(tournamentDirectory, "settings.txt");
        string settings = "";
        settings += "playerTeam " + playerTeam.getName() + "\n";
        settings += "field " + field.getName() + "\n";
        settings += "mode " + WinCondition.modeToString(mode) + "\n";
        settings += "goalsToWin " + goalsToWin.ToString() + "\n";
        settings += "timeToEnd " + timeToEnd.ToString();
        File.WriteAllText(tournamentSettings, settings);
    }

    private void saveTournamentDifficulties()
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

    private void saveGroupsData()
    {
        createTournamentDirectoryIfNone();

        string tournamentGroupsPath = Path.Combine(tournamentDirectory, "groups.txt");
        string tournamentGroupsData = "";

        foreach(KeyValuePair<(char, int), TeamDataOnGroupPhase> teamDataOnGroupPhase in teamsDataOnGroupPhase)
        {
            string group = teamDataOnGroupPhase.Key.Item1.ToString();
            string idx = teamDataOnGroupPhase.Key.Item2.ToString();
            TeamDataOnGroupPhase data = teamDataOnGroupPhase.Value;
            tournamentGroupsData += 
            group + " " + idx + " " + data.team.getName() + " " + data.points + " " + data.matchesPlayed + " " +
            data.wins + " " + data.draws + " " + data.losses + " " +
            data.goalsFor + " " + data.goalsAgainst + " " + data.goalDifference + '\n';
        }
        // remove trailing end of line
        tournamentGroupsData = tournamentGroupsData.Remove(tournamentGroupsData.Length - 1);

        File.WriteAllText(tournamentGroupsPath, tournamentGroupsData);
    }

    private void saveRoundsData()
    {
        createTournamentDirectoryIfNone();

        string tournamentRoundPath = Path.Combine(tournamentDirectory, "groups.txt");
        string tournamentRoundData = "";

        tournamentRoundData += roundsPlayed.ToString() + "\n";
        File.WriteAllText(tournamentRoundPath, tournamentRoundData);
    }

    public void simulateRound()
    {
        if(isOnGroupPhase())
            simulateGroupRound();
        
        saveRoundsData();
    }

    public bool isOnGroupPhase()
    {
        return roundsPlayed < 3;
    }

    public TimeOfMatch getTimeOfMatch()
    {
        return TimeOfMatch.Evening;
    }

    private void simulateGroupRound()
    {
        int currentRound = roundsPlayed + 1;
        List<(int, int)> matches = RoundRobin.generateMatches(4, currentRound);

        for(int i = 0; i < 8; i++)
        {
            char group = ((char)('A' + i));
            foreach( (int idxA, int idxB) in matches )
            {
                TeamDataOnGroupPhase firstTeamData = teamsDataOnGroupPhase[(group, idxA)];
                TeamDataOnGroupPhase secondTeamData = teamsDataOnGroupPhase[(group, idxB)];

                if(firstTeamData.team.getName() == playerTeam.getName() )
                {
                    oponent = secondTeamData.team;
                    continue;
                }
                
                if(secondTeamData.team.getName() == playerTeam.getName() )
                {
                    oponent = firstTeamData.team;
                    continue;
                }

                firstTeamData.matchesPlayed++;
                secondTeamData.matchesPlayed++;

                int firstTeamDifficulty = difficulties[firstTeamData.team.getName()];
                int secondTeamDifficulty = difficulties[secondTeamData.team.getName()];

                int endCondition = 0;
                if(mode == WinCondition.Mode.Goals)
                    endCondition = goalsToWin;
                else
                    endCondition = timeToEnd;
                
                (int firstTeamGoals, int secondTeamGoals) = new SimulateMatch(mode, endCondition).simulate(firstTeamDifficulty, secondTeamDifficulty);
                
                firstTeamData.goalsFor += firstTeamGoals;
                secondTeamData.goalsFor += secondTeamGoals;

                firstTeamData.goalsAgainst += secondTeamGoals;
                secondTeamData.goalsAgainst += firstTeamGoals;

                firstTeamData.goalDifference += (firstTeamGoals - secondTeamGoals);
                secondTeamData.goalDifference += (secondTeamGoals - firstTeamGoals);

                if(firstTeamGoals > secondTeamGoals)
                {
                    firstTeamData.wins++;
                    secondTeamData.losses++;

                    firstTeamData.points += 3;
                }
                else if(secondTeamGoals > firstTeamGoals)
                {
                    secondTeamData.wins++;
                    firstTeamData.losses++;

                    secondTeamData.points += 3;
                }
                else
                {
                    firstTeamData.draws++;
                    secondTeamData.draws++;

                    firstTeamData.points += 1;
                    secondTeamData.points += 1;
                }
            }
        }

        saveGroupsData();
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