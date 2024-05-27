namespace lab_5.LightHTML;

class LightTextNode : LightNode
{
    private string text;
    public LightTextNode(string text)
    {
        this.text = text;
        OnCreated();
    }

    public override string OuterHTML
    {
        get
        {
            OnTextRendered();
            return text;
        }
    }

    public override string InnerHTML => text;
    
    protected override void OnCreated()
    {
        Console.WriteLine("LightTextNode created.");
    }

    protected override void OnTextRendered()
    {
        Console.WriteLine("Text rendered: " + text);
    }
}