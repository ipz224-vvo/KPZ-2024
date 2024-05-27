using lab_5.LightHTML;

namespace lab_5.Iterator;

class InWidthIterator : IIterator<LightNode>
{
    private Queue<LightNode> queue;

    public InWidthIterator(LightNode root)
    {
        queue = new Queue<LightNode>();
        queue.Enqueue(root);
    }

    public bool HasNext()
    {
        return queue.Count > 0;
    }

    public LightNode Next()
    {
        LightNode node = queue.Dequeue();
        if (node is LightElementNode elementNode)
        {
            foreach (var child in elementNode.GetChilds())
            {
                queue.Enqueue(child);
            }
        }

        return node;
    }
}