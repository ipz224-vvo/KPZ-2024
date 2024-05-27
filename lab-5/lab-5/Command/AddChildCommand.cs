using lab_5.LightHTML;

namespace lab_5.Command;

class AddChildCommand : ICommand<LightNode>
{
    private LightNode child;

    public AddChildCommand(LightNode child)
    {
        this.child = child;
    }

    public void Execute(LightNode node)
    {
        if (node is LightElementNode elementNode)
        {
            elementNode.AddChild(child);
        }
    }
}