namespace FieldNamespace
{
public enum TimeOfMatch
{
    Noon,
    Afternoon,
    Evening
}

public static class TimeOfMatchUtils
{

    public static string TimeOfMatchToString(TimeOfMatch time)
    {
        if(time == TimeOfMatch.Noon)
            return "Noon";
        else if(time == TimeOfMatch.Afternoon)
            return "Afternoon";
        else if(time == TimeOfMatch.Evening)
            return "Evening";

        return "Noon";
    }

    public static TimeOfMatch stringToTimeOfMatch(string time)
    {
        if(time == "Noon")
            return TimeOfMatch.Noon;
        else if(time == "Afternoon")
            return TimeOfMatch.Afternoon;
        else if(time == "Evening")
            return TimeOfMatch.Evening;
        
        throw new System.Exception("Name of time of match does not relate to any time.");
    }

}

}