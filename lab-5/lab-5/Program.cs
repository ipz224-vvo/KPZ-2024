using lab_4.Strategy;
using lab_5.LightHTML;
using lab_5.Visitor;

namespace lab_5;

class Program
{
    static void Main(string[] args)
    {
        LightNodeFormatter nodeFormatter = new();
        
        LightElementNode html = new("html", DisplayType.Block, ClosingType.Double);
        LightElementNode head = new("head", DisplayType.Block, ClosingType.Double);
        LightElementNode title = new("title", DisplayType.Block, ClosingType.Double);
        LightTextNode titleText = new("State");
        title.AddChild(titleText);
        head.AddChild(title);
        html.AddChild(head);
        
        LightElementNode body = new("body", DisplayType.Block, ClosingType.Double);
        LightElementNode div = new("div", DisplayType.Block, ClosingType.Double);
        LightTextNode divText = new("TEST");
        div.AddChild(divText);
        body.AddChild(div);
        
        LightElementNode divBold = new("div", DisplayType.Block, ClosingType.Double);
        var textBold = divText.Accept(nodeFormatter);
        divBold.AddChild(textBold);
        body.AddChild(divBold);
        
        LightElementNode usualDiv = new("div", DisplayType.Block, ClosingType.Double);
        LightTextNode usualText = new("Usual");
        usualDiv.AddChild(usualText);
        var greenDiv = usualDiv.Accept(nodeFormatter);
        body.AddChild(greenDiv);

        string imageSrc = "https://i.pinimg.com/474x/17/64/f5/1764f598da749a1a100b391695e43865.jpg";
        LightImageNode imageNode = new(imageSrc, "flower", new NetworkImageLoader());
        var borderedImage = imageNode.Accept(nodeFormatter);
        body.AddChild(borderedImage);

        html.AddChild(body);
        Console.WriteLine(html.OuterHTML);
        File.WriteAllText("visitor.html", html.OuterHTML);
    }
}