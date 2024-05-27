using lab_5.Visitor;
using lab_5.State;

namespace lab_5.LightHTML;

abstract class LightNode
{
    public virtual IState State { get; set; }
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }

    public abstract LightNode Accept(ILightNodeVisitor visitor);

    public string Render()
    {
        OnCreated();
        string html = OuterHTML;
        OnInserted();
        return html;
    }

    protected virtual void OnCreated()
    {
    }

    protected virtual void OnInserted()
    {
    }

    protected virtual void OnClassListApplied()
    {
    }

    protected virtual void OnTextRendered()
    {
    }

    protected virtual void OnScriptAdded()
    {
    }
}