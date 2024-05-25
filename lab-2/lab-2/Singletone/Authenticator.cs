namespace lab_2.Singletone;

public class Authenticator
{
    private static Authenticator _instance;
    private static readonly object Lock = new();

    private Authenticator()
    {
    }

    public static Authenticator Instance
    {
        get
        {
            if (_instance != null)
                return _instance;

            lock (Lock)
            {
                _instance ??= new Authenticator();
            }

            return _instance;
        }
    }

    public void Authenticate()
    {
        Console.WriteLine("Authenticating...");
    }
}