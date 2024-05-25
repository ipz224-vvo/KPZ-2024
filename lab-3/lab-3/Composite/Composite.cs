namespace lab_3.Composite;

using System;
using System.Collections.Generic;

abstract class LightNode
{
    public abstract string OuterHTML { get; }
    public abstract string InnerHTML { get; }
}

class LightTextNode : LightNode
{
    private string text;

    public LightTextNode(string text)
    {
        this.text = text;
    }

    public override string OuterHTML => text;
    public override string InnerHTML => text;
}

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

class LightElementNode : LightNode
{
    private string tagName;
    private DisplayType displayType;
    private ClosingType closingType;
    private List<string> cssClasses;
    private List<LightNode> children;

    public LightElementNode(string tagName, DisplayType displayType, ClosingType closingType, List<string> cssClasses)
    {
        this.tagName = tagName;
        this.displayType = displayType;
        this.closingType = closingType;
        this.cssClasses = cssClasses;
        this.children = new List<LightNode>();
    }

    public void AddChild(LightNode child)
    {
        children.Add(child);
    }

    public void ClearChilds()
    {
        children.Clear();
    }

    public override string OuterHTML
    {
        get
        {
            string cssClassesString = cssClasses.Count != 0 ? $" class=\"{string.Join(" ", cssClasses)}\"" : "";
            string startTag = $"<{tagName}{cssClassesString}>";
            string endTag = closingType == ClosingType.Single ? "/" : $"</{tagName}>";
            string innerHTML = string.Join("", children.Select(child => child.OuterHTML));
            return startTag + innerHTML + endTag;
        }
    }

    public override string InnerHTML
    {
        get { return string.Join("", children.Select(child => child.OuterHTML)); }
    }
}