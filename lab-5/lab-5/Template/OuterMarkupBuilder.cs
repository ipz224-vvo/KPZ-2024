using System.Text;
using lab_5.LightHTML;

namespace lab_5.Template;

interface OuterMarkupBuilder
{
    void AddStartTag(string startTag);
    void AddId(Guid guid);
    void AddCssClasses(List<string> cssClasses);
    void AddInnerMarkup(List<LightNode> childs);
    void AddEventListeners(EventSubscription eventSubcriptions);
    string BuildMarkup(string tagName, Guid id, List<string> cssClasses, List<LightNode> childs,
        ClosingType closingType, EventSubscription eventSubscription);
}