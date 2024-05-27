using lab_5.LightHTML;

namespace lab_5.State;

interface IState
{
    void AddChild(LightNode node, LightNode parent);
}