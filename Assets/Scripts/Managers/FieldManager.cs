namespace FieldNamespace{
class FieldManager
{
    public Field field;

    private FieldManager() {
        field = new Field("striped_field");
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