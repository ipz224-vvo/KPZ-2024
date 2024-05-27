namespace lab_5.LightHTML;

abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }

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