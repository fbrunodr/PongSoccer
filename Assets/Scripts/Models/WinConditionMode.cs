
namespace WinConditionNamespace
{
public class WinCondition
{
public enum Mode
{
    Time,
    TimeAndGoldenGoal,
    Goals
}

public static string modeToString(Mode winConditionMode)
{
    if(winConditionMode == Mode.Time)
        return "Time";
    else if(winConditionMode == Mode.TimeAndGoldenGoal)
        return "Time and golden goal";
    else if(winConditionMode == Mode.Goals)
        return "Goals";
    
    throw new System.Exception("Mode not covered by modeToString.");
}

public static Mode stringToMode(string winConditionMode)
{
    if(winConditionMode == "Time")
        return Mode.Time;
    else if(winConditionMode == "Time and golden goal")
        return Mode.TimeAndGoldenGoal;
    else if(winConditionMode == "Goals")
        return Mode.Goals;

    throw new System.Exception("Name of mode does not relate to any mode.");
}

}
}