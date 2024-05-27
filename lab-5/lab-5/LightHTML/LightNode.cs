using lab_5.Visitor;

namespace lab_5.LightHTML;

abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }
    public abstract LightNode Accept(ILightNodeVisitor visitor);
}