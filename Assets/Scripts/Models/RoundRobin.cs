using System.Collections;
using System.Collections.Generic;

namespace Utils
{
public static class RoundRobin
{
    public static List<(int, int)> generateMatches(int numberOfTeams, int round)
    {
        List<int> teamsPos = new List<int>();
        teamsPos.Add(0);
        for(int i = 1; i < numberOfTeams; i++)
            teamsPos.Add( (i + round - 1)%numberOfTeams );

        List<(int, int)> pairs = new List<(int, int)>();
        for(int i = 0; i < numberOfTeams/2; i++)
            pairs.Add( (teamsPos[i], teamsPos[numberOfTeams-1-i]) );

        return pairs;
    }
}
}