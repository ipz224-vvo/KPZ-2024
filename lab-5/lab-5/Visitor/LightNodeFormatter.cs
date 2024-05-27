using lab_5.LightHTML;

namespace lab_5.Visitor;

class LightNodeFormatter : ILightNodeVisitor
{
    public LightTextNode Visit(LightTextNode node)
    {
        // making text bold
        return new LightTextNode($"<b>{node.OuterHTML}</b>");
    }

    public LightElementNode Visit(LightElementNode node)
    {
        // making background green
        LightElementNode greenNode =
            new("div", DisplayType.Block, ClosingType.Double, cssStyles: "background-color: green;");
        greenNode.AddChild(node);
        return greenNode;
    }

    public LightElementNode Visit(LightImageNode node)
    {
        LightImageNode lightImageNode = new(node.GetSrc(), node.GetAlt(), node.GetLoader(),node.GetCssStyles() +
            " display: block; width: 100px; height: 100px;");
        // adding black margins
        LightElementNode borders = new("div", DisplayType.Block, ClosingType.Double,
            cssStyles:
            "display: inline-block; padding: 2.5%; box-sizing: border-box; background-color: lightgrey;");
        borders.AddChild(lightImageNode);
        return borders;
    }
}