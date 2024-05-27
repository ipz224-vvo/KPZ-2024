namespace lab_5.Iterator;
using lab_5.LightHTML;

class InDepthIterator : IIterator<LightNode>
{
    private Stack<LightNode> stack;

    public InDepthIterator(LightNode root)
    {
        stack = new Stack<LightNode>();
        stack.Push(root);
    }

    public bool HasNext()
    {
        return stack.Count > 0;
    }

    public LightNode Next()
    {
        LightNode node = stack.Pop();
        if (node is LightElementNode elementNode)
        {
            foreach (var child in elementNode.GetChilds())
            {
                stack.Push(child);
            }
        }
        return node;
    }
}