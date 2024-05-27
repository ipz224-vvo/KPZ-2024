using System.Text;
using lab_4.Strategy;

namespace lab_5.LightHTML;

enum DisplayType
{
    Block,
    Row
}

enum ClosingType
{
    Single,
    Double
}

public delegate void EventHandler(object sender, EventArgs e);

class LightElementNode : LightNode
{
    private Guid id = Guid.NewGuid();
    private string plainId => id.ToString();
    private string tagName;
    private DisplayType displayType;
    private ClosingType closingType;
    private List<string> cssClasses;
    private List<LightNode> children;
    public EventSubscription EventSubscriptions { get; set; }

    public LightElementNode(string tagName, DisplayType displayType, ClosingType closingType,
        List<string> cssClasses = null,
        EventSubscription eventSubscriptions = null)
    {
        
        this.tagName = tagName;
        this.displayType = displayType;
        this.closingType = closingType;
        this.cssClasses = cssClasses ?? new List<string>();

        this.children = new List<LightNode>();
        EventSubscriptions = eventSubscriptions ?? new EventSubscription();
        OnCreated();
    }

    public void AddChild(LightNode child)
    {
        children.Add(child);
    }

    public void ClearChilds()
    {
        children.Clear();
    }

    public void AddSubscription(string eventName, string handler)
    {
        EventSubscriptions.Subscribe(eventName, handler);
    }
    public void RemoveSubscription(string eventName, string handler)
    {
        EventSubscriptions.Unsubscribe(eventName, handler);
    }

    public override string OuterHTML
    {
        get
        {
            string idAttribute = $"";
            StringBuilder script = new("");
            var eventHandlers = EventSubscriptions.GetEventHandlers();
            if (eventHandlers != null && eventHandlers.Count != 0)
            {
                script = new("\n<script>");
                foreach (var keyValuePair in eventHandlers)
                {
                    string eventName = keyValuePair.Key;
                    var handlers = keyValuePair.Value;
                    foreach (var handler in handlers)
                    {
                        var eventListener =
                            $"document.getElementById(\'{plainId}\').addEventListener(\'{eventName}\', {handler})\n";
                        script.Append(eventListener);
                    }
                }
                script.Append("</script>");
                OnScriptAdded();
                idAttribute = $" id=\"{plainId}\" ";
            }

            string cssClassesString = cssClasses.Count != 0 ? $" class=\"{string.Join(" ", cssClasses)}\"" : "";
            OnClassListApplied();
            string startTag = $"<{tagName}{idAttribute}{cssClassesString}>";
            string endTag = closingType == ClosingType.Single ? "/" : $"</{tagName}>";
            string innerHTML = string.Join("", children.Select(child => child.OuterHTML));

            OnInserted();
            return startTag + innerHTML + endTag + script;
        }
    }

    public override string InnerHTML
    {
        get { return string.Join("", children.Select(child => child.OuterHTML)); }
    }
    
    protected override void OnCreated()
    {
        Console.WriteLine($"Element {tagName} created.");
    }

    protected override void OnInserted()
    {
        Console.WriteLine($"Element {tagName} inserted.");
    }

    protected override void OnClassListApplied()
    {
        if (cssClasses != null && cssClasses.Count != 0)
        {
            Console.WriteLine($"Class list applied to {tagName}: {string.Join(", ", cssClasses)}");
            return;
        }
        Console.WriteLine($"No classes have been applied to {tagName}");
    }

    protected override void OnScriptAdded()
    {
        var eventHandlers = EventSubscriptions.GetEventHandlers();
        if (eventHandlers == null || eventHandlers.Count == 0)
        {
            Console.WriteLine($"No classes have been added to {tagName}");
            return;
        }
        
        Console.WriteLine($"Scripts applied to {tagName}:\n");
        foreach (var keyValuePair in eventHandlers)
        {
            string eventName = keyValuePair.Key;
            var handlers = keyValuePair.Value;
            foreach (var handler in handlers)
            {
                Console.WriteLine($"document.getElementById(\'{plainId}\').addEventListener(\'{eventName}\', {handler})\n");
            }
        }
    }
}