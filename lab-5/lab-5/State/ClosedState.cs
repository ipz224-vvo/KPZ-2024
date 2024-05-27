using lab_5.LightHTML;

namespace lab_5.State;

class ClosedState : IState
{
    private static ClosedState _instance;
    private static readonly object _lock = new object();

    public static ClosedState GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                _instance ??= new ClosedState();
            }
        }
        return _instance;
    }
    public void AddChild(LightNode node, LightNode parent)
    {
        throw new InvalidOperationException("Cannod add a child to a node with closed state.");
    }
}