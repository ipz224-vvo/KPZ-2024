using lab_5.LightHTML;

namespace lab_5.Visitor;

interface ILightNodeVisitor
{
    LightTextNode Visit(LightTextNode node);
    LightElementNode Visit(LightElementNode node);
    LightElementNode Visit(LightImageNode node);
}