using lab_5.LightHTML;
using lab_5.SingletonPattern;

namespace lab_5.State;

class OpenState : IState
{
    private static OpenState _instance;
    private static readonly object _lock = new object();

    public static OpenState GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock)
            {
                _instance ??= new OpenState();
            }
        }
        return _instance;
    }
    public void AddChild(LightNode node, LightNode parent)
    {
        if(parent is LightElementNode parentElementNode)
            parentElementNode.children.Add(node);
    }
}