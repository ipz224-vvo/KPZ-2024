using System.Text;
using lab_5.LightHTML;

namespace lab_5.Template;

class OuterHTMLBuilder : OuterMarkupBuilder
{
    private string _plainId;
    private StringBuilder _attributesBuilder = new();
    private StringBuilder _innerMarkupBuilder = new();
    private StringBuilder _scriptsBuilder = new();

    public void AddStartTag(string startTag)
    {
        _attributesBuilder.Append($"<{startTag}");
    }

    public void AddId(Guid id)
    {
        _plainId = id.ToString();
        _attributesBuilder.Append($" id=\"{_plainId}\' ");
    }

    public void AddCssClasses(List<string> cssClasses)
    {
        string cssClassesString = cssClasses.Count != 0 ? $" class=\"{string.Join(" ", cssClasses)}\" " : "";
        _attributesBuilder.Append(" " + cssClassesString + " ");
    }

    public void AddInnerMarkup(List<LightNode> childs)
    {
        _innerMarkupBuilder.Append(string.Join("\n", childs.Select(child => child.OuterHTML)));
    }

    public void AddEventListeners(EventSubscription eventSubcriptions)
    {
        var eventHandlers = eventSubcriptions?.GetEventHandlers();
        if (eventHandlers == null || eventHandlers.Count == 0) return;
        _scriptsBuilder = new("<script>");
        foreach (var keyValuePair in eventHandlers)
        {
            string eventName = keyValuePair.Key;
            var handlers = keyValuePair.Value;
            handlers.ForEach(handler =>
                _scriptsBuilder.Append(
                    $"document.getElementById(\'{_plainId}\').addEventListener(\'{eventName}\', {handler})\n"));
        }

        _scriptsBuilder.Append("</script>\n");
    }

    public string BuildMarkup(string tagName, Guid id, List<string> cssClasses, List<LightNode> childs,
        ClosingType closingType, EventSubscription eventSubscription)
    {
        AddStartTag(tagName);
        AddId(id);
        AddCssClasses(cssClasses);
        AddInnerMarkup(childs);
        AddEventListeners(eventSubscription);
        if (closingType == ClosingType.Single)
            return _attributesBuilder + " />" + _scriptsBuilder;
        return _attributesBuilder + ">\n" + _innerMarkupBuilder + "</" + tagName + ">" + _scriptsBuilder;
    }
}