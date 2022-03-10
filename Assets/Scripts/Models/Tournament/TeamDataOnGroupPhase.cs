using TeamNamespace;

namespace TournamentNamespace
{
public class TeamDataOnGroupPhase
{
    public Team team;
    public int points, matchesPlayed, wins, draws, losses, goalsFor, goalsAgainst, goalDifference;

    public TeamDataOnGroupPhase(Team team)
    {
        this.team = team;
        points = 0;
        matchesPlayed = 0;
        wins = 0;
        draws = 0;
        losses = 0;
        goalsFor = 0;
        goalsAgainst = 0;
        goalDifference = 0;
    }
}
}