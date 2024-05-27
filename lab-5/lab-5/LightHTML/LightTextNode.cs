using lab_5.Visitor;

namespace lab_5.LightHTML;

class LightTextNode : LightNode
{
    private string text;

    public LightTextNode(string text)
    {
        this.text = text;
    }

    public void SetNode(LightTextNode textNode)
    {
        text = textNode.InnerHTML;
    }

    public override string OuterHTML => text;
    public override string InnerHTML => text;
    public override LightNode Accept(ILightNodeVisitor visitor)
    {
        return visitor.Visit(this);
    }
}