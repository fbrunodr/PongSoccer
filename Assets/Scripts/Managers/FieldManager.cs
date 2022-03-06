namespace FieldNamespace{
class FieldManager
{
    public Field field;
    public string time;

    private FieldManager()
    {
        field = new Field("neighborhood_field");
        time = "Noon";
    }

    private static FieldManager _instance;

    private static readonly object _lock = new object();

    public static FieldManager GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new FieldManager();
                }
            }
        }
        return _instance;
    }
}
}