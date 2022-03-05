using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DifficutiesNamespace{
class DifficutiesManager
{
    public Dictionary<string, int>  difficulties;
    public readonly Dictionary<string, int>  standardDifficulties;

    private DifficutiesManager()
    {
        startDifficultiesData();

        string standardDifficutiesPath = "GameData/resetDifficult";
        string standardDifficutiesData = Resources.Load<TextAsset>(standardDifficutiesPath).ToString();
        standardDifficulties = new Dictionary<string, int>();
        foreach(string line in standardDifficutiesData.Split('\n'))
        {
            string[] info = line.Split(' ');
            string team = info[0];
            int difficult = int.Parse(info[1]);
            standardDifficulties.Add(team, difficult);
        }
    }

    private void startDifficultiesData()
    {
        string difficultiesPath = Path.Combine(Application.persistentDataPath, "difficulties.txt");
        Debug.Log(difficultiesPath);
        if(!File.Exists(difficultiesPath))
        {
            string standardDifficutiesPath = "GameData/resetDifficult";
            string standardDifficutiesData = Resources.Load<TextAsset>(standardDifficutiesPath).ToString();

            File.WriteAllText(difficultiesPath, standardDifficutiesData);
        }

        string difficultiesData = File.ReadAllText(difficultiesPath);
        difficulties = new Dictionary<string, int>();
        foreach(string line in difficultiesData.Split('\n'))
        {
            string[] info = line.Split(' ');
            string team = info[0];
            int difficult = int.Parse(info[1]);
            difficulties.Add(team, difficult);
        }
    }

    public void saveTeamsData()
    {
        string difficultiesData = "";
        foreach(KeyValuePair<string, int> pair in difficulties)
        {
            string teamName = pair.Key;
            int difficult = pair.Value;
            difficultiesData = difficultiesData + teamName + " " + difficult + "\n";
        }
        // remove trailing end of line
        difficultiesData = difficultiesData.Remove(difficultiesData.Length - 1);

        string difficultiesPath = Path.Combine(Application.persistentDataPath, "difficulties.txt");
        File.WriteAllText(difficultiesPath, difficultiesData);
    }

    private static DifficutiesManager _instance;

    private static readonly object _lock = new object();

    public static DifficutiesManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new DifficutiesManager();
                }
            }
        }
        return _instance;
    }
}
}