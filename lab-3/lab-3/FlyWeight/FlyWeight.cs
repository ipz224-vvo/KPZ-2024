using lab_3.Composite;

namespace lab_3.FlyWeight;

class LightElementFactory
{
    private Dictionary<string, LightElementNode> elements;

    public LightElementFactory()
    {
        elements = new Dictionary<string, LightElementNode>();
    }

    public Func<string, DisplayType, ClosingType, List<string>, string, LightElementNode> GetElement;

    private LightElementNode GetElementOptimized(string tagName, DisplayType displayType, ClosingType closingType,
        List<string> cssClasses, string line)
    {
        string key = $"{tagName}_{displayType}_{closingType}_{string.Join(",", cssClasses)}_{line}";

        if (!elements.ContainsKey(key))
        {
            elements[key] = new LightElementNode(tagName, displayType, closingType, cssClasses);
            LightTextNode textNode = new LightTextNode(line);
            elements[key].AddChild(textNode);
        }

        return elements[key];
    }

    private LightElementNode GetElementUnOptimized(string tagName, DisplayType displayType, ClosingType closingType,
        List<string> cssClasses, string line)
    {
        var node = new LightElementNode(tagName, displayType, closingType, cssClasses);
        LightTextNode textNode1 = new LightTextNode(line);
        node.AddChild(textNode1);
        return node;
    }

    public void ChangeToOptimized()
    {
        GetElement = GetElementOptimized;
    }

    public void ChangeToUnOptimized()
    {
        GetElement = GetElementUnOptimized;
    }
}