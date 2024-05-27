namespace lab_5.SingletonPattern;

public sealed class Singleton
{
    private static Singleton _instance;
    private static readonly object _lock = new object();

    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }
        }

        return _instance;
    }
}